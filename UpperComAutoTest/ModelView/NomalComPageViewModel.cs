
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using UpperComAutoTest.Entry;
using UpperComAutoTest.Extend;
using UpperComAutoTest.Model;
using UpperComAutoTest.MyControls;
using UpperComAutoTest.SendorEvent;
using UPPERIOC.Interface;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.Sendor;

namespace UpperComAutoTest.ModelView
{
	[IOCObject]
	public class NomalComPageViewModel : IVIewModel
	{
		private NomalComPageModel m;


		public NomalComPageModel NomalModel { get => m; set => m = value; }
		AsyncTimer timer = new AsyncTimer();
		public bool AutoSend { get=> timer.Enable;
			internal set {
				if (value)
				{
					timer.Start();
				}
				else
				{
					timer.Stop();

				}
			}
		}
		public int AutoSendTime { get =>timer.period; internal set => timer.period = value; }

		public NomalComPageViewModel(NomalComPageModel NomalModel)
		{
			this.NomalModel = NomalModel;
			// 初始化命令和其他属性  
		
		}
		public void SetRevent(FCT.ReciveMess Receve) { 
			NomalModel.SerialPort.REvent += Receve;

		}
		internal void StartCom(Button? startbtn, Button? stopbutton, Action<bool> gp1)
		{
			MyTips.ShowTips(startbtn.FindForm(), Tipstype.Error, "串口打开出现异常", 2000);
			if (NomalModel.SerialPort.IsOpen)
			{
				MyTips.ShowTips(startbtn.FindForm(), Tipstype.Error, "串口已经打开了", 2000, true);
				startbtn.Enabled = false;
				return;
			}
			startbtn.Enabled = false;

			Task.Factory.StartNew(() =>
			{
				try
				{
					NomalModel.SerialPort.Open();
					startbtn.Invoke(() =>
					{
						gp1?.Invoke(true);

						stopbutton.Enabled = true;
					});
				}
				catch (Exception)
				{
					MyTips.ShowTips(startbtn.FindForm(), Tipstype.Error, "串口打开出现异常", 2000, true);
					startbtn.Invoke(() =>
					{
						gp1?.Invoke(false);

						startbtn.Enabled = true;
					});


				}
			});
		}

		internal void StopCom(Button? stopbutton, Button Startbtn, Action<bool> gp1)
		{
			if (!NomalModel.SerialPort.IsOpen)
			{
				MyTips.ShowTips(stopbutton.FindForm(), Tipstype.Error, "串口已经关闭了", 2000, true);
				stopbutton.Enabled = false;
				return;
			}
			stopbutton.Enabled = false;

			Task.Factory.StartNew(() =>
			{
				try
				{
					NomalModel.SerialPort.Close();
					stopbutton.Invoke(() =>
					{
						gp1?.Invoke(true);


						Startbtn.Enabled = true;
					});
				}
				catch (Exception)
				{
					MyTips.ShowTips(stopbutton.FindForm(), Tipstype.Error, "串口关闭出现异常", 2000, true);
					stopbutton.Invoke(() =>
					{
						stopbutton.Enabled = true;
						gp1?.Invoke(false);


					});


				}
			});
		}

		internal void ReceveTo16(bool receve16x, RichTextBox richTextBox_r)
		{
			richTextBox_r.Text = NomalModel.SerialPort.data.ListByteDataToStr(receve16x, NomalModel.Timestamp);

		}

		internal void SendTo16(bool send16x, RichTextBox richTextBox_s)
		{


		}

		internal void ChangeSelectionTo16x(RichTextBox richTextBox_s)
		{
			string str16 = string.Join(" ", Encoding.Default.GetBytes(richTextBox_s.SelectedText).ByteArrayToHex(" "));
			richTextBox_s.SelectedText = str16;
		}

		internal void ChangeSelectionTostring(RichTextBox richTextBox_s)
		{
			try
			{

				var str16 = richTextBox_s.SelectedText.ToBitArray();
				richTextBox_s.SelectedText = Encoding.Default.GetString(str16);
			}
			catch (Exception)
			{
				MyTips.ShowTips(richTextBox_s.FindForm(), Tipstype.Error, "转换出现异常，数字对16进制是否过大");
			}
		}

		internal void Send16(Action<ByteMessage> cellback)
		{
			ByteMessage btm = null;
			Task.Factory.StartNew(() =>
			{
				try
				{
					byte[] str16 = null;
					str16 = NomalModel.SendMsg.ToBitArray();
				
					btm = new ByteMessage() { Data = str16, Time = DateTime.Now, IsSend = true };
					NomalModel.SerialPort.Write(str16, 0, str16.Length);
					NomalModel.SerialPort.data.Enqueue(btm);

					cellback?.Invoke(btm);
				}
				catch (Exception ex)
				{
					//	richTextBox_s.Invoke(() => {
					cellback?.Invoke(new ByteMessage() { Err = new Exception("转换出现异常，数字对16进制是否过大") });
				//	});

				}
			});
		}
		internal void Send()
		{
			ByteMessage btm = null;
			try
				{
				if (!NomalModel.SerialPort.IsOpen)
				{
					return;
				}
					byte[] str16 = null;
					str16 = NomalModel.SendMsg.ToBitArray();

					btm = new ByteMessage() { Data = str16, Time = DateTime.Now, IsSend = true };
					NomalModel.SerialPort.Write(str16, 0, str16.Length);
					NomalModel.SerialPort.data.Enqueue(btm);
				Sendor.Publish<AutoRefeashEvent>(new AutoRefeashEvent());

			}
			catch (Exception ex)
			{
				var ece = new StopAutosendTipEvent()
				{
					Msg = "发送错误，已停止发送",
					showinwindow = true
					,
					type = Tipstype.Error,
					waittime = 2000
				};
				Sendor.Publish<StopAutosendTipEvent>(ece);

				AutoSend = false;
			}

		}

		public override void Create()
		{
			//NomalModel = new NomalComPageModel();
			
			timer.callback += () =>
			{
				
				Send();
			};
		}

		public override void Destroy()
		{
			
		}

		internal void SetBlackBackGroud(bool @checked, Action<bool> value)
		{
			NomalModel.Blackback = @checked;
			value?.Invoke(true);
		}

		internal void ClearReceive(Action<bool> value)
		{
			NomalModel.SerialPort.data.Clear();
			value?.Invoke(true);
		}
	}
}
