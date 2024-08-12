using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UpperComAutoTest.Entry;
using UpperComAutoTest.Entry.IEventFileModel;
using UpperComAutoTest.SendorEvent;
using UPPERIOC;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC2.UPPER.USendor.Center;

namespace FCT
{
    public delegate void ReciveMess(ByteMessage Reciver);
	[IOCObject]
	public class CurrentSerialPort 
	{
		/// <summary>
		/// 接受消息的事件
		/// </summary>
		public event ReciveMess REvent;
		private SerialPort ser;
		private object writelock =new object();
		private object readlock = new object();
		public bool IsOpen { get => ser.IsOpen; }
		public string PortName { get => ser.PortName; set => ser.PortName = value; }
		public Parity Parity { get=>ser.Parity; set=>ser.Parity = value; }
		public int BaudRate { get=> ser.BaudRate; internal set=> ser.BaudRate =value; }
		public StopBits StopBits { get=> ser.StopBits; internal set => ser.StopBits = value; }
		public int WriteBufferSize { get => ser.WriteBufferSize; internal set => ser.WriteBufferSize = value; }
		public int ReadBufferSize { get=> ser.ReadBufferSize; internal set=>ser.ReadBufferSize  = value; }
		public int DataBits { get => ser.DataBits; internal set => ser.DataBits = value; }
		public bool RtsEnable { get => ser.RtsEnable; internal set => ser.RtsEnable = value; }
		public bool DtrEnable { get => ser.DtrEnable; internal set => ser.DtrEnable = value; }
		
		
		public 	ConcurrentQueue<ByteMessage> data = new ConcurrentQueue<ByteMessage>();
		public void LockMethod(Action acr,object lockobj) {
			lock (lockobj)
			{
				
				acr.Invoke();
			}
		}
		public CurrentSerialPort()
			
		{

			ser = new SerialPort();
			ser.DataReceived += DataReceve;
		}
		
		public CurrentSerialPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits) 
		{
			ser = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
			ser.DataReceived += DataReceve;
			ser.ReadTimeout = 2000 ;
			//USB_I2C.WriteTimeout = WriteTimeout == "" ? 2000 : Convert.ToInt32(WriteTimeout);
			ser.WriteBufferSize = 2048;
			ser.ReadBufferSize = 2048;
			ser.WriteTimeout = 2000;
		}

		private void DataReceve(object sender, SerialDataReceivedEventArgs e)
		{
			LockMethod(() => {
			if (ser.BytesToRead > 0)
			{
				byte[] bs = new byte[ser.BytesToRead];
				ser.Read(bs, 0, bs.Length);
				var bts = new ByteMessage() { Time = DateTime.Now, Data = bs, IsSend = false };
				EventFileModel eve = UPPERIOCApplication.Container.GetInstance(typeof(EventFileModel)) as EventFileModel;
				eve.Msgevens.ForEach(item => {
					if (item.Receivebytemess.Data.SequenceEqual(bs))
					{
						item.Sendbytemess.IsSend = true;
						item.Sendbytemess.Time = DateTime.Now;
						SendorCenter.Publish<CurrentPortSendMessageEvent>(new CurrentPortSendMessageEvent() {  Msg =  item.Sendbytemess});
					//	Write(item.Sendbytemess.Data,0, item.Sendbytemess.Data.Length);
					}
				});
					data.Enqueue(bts);
					REvent?.Invoke(bts);
				}
			}, readlock);
		}
		public void Write(byte[] data,int st,int en)
		{
			LockMethod(() => {
				ser.Write(data, st,en);
			}, writelock);
		}
		public void Write(byte[] data)
		{
			LockMethod(() => {
				ser.Write(data,0,data.Length);
			},writelock);
		}
		/// <summary>
		/// 读取数据，如果为0的话就回复null
		/// </summary>
		/// <returns></returns>
		public ByteMessage Read()
		{
			ByteMessage data = null;
			LockMethod(() => {
				if (this.data.Count > 0)
				{
					Thread.Sleep(20);
					data = this.data.Last() ;
					this.data.Clear();
				}

			}, readlock);
			return data;
		}
		public void Close()
		{
			if (!IsOpen)
			{
				throw new Exception("已经关闭");
			}
			LockMethod(() => {

				LockMethod(() => {
					ser.Close();
				}, readlock);
			}, writelock);
		}
		public void Open()
		{
			if (IsOpen)
			{
				throw new Exception("已经打开");
			}
			LockMethod(() => {

				LockMethod(() => {
					ser.Open();
				}, readlock);
			}, writelock);
		}

		/*public string iss_receive(int time = 300)

		{
					Thread.Sleep(500);
			byte[] data = new byte[0];
			LockMethod(() => {
				if (this.data.Count > 0)
				{
					Thread.Sleep(20);
					data = this.data.ToArray();
					this.data.Clear();
				}

			}, readlock);
			return Encoding.ASCII.GetString(data);
		}*/
	}
}
