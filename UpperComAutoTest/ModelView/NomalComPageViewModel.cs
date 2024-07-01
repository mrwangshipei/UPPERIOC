
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

namespace UpperComAutoTest.ModelView
{
	public class NomalComPageViewModel : _IViewModel.IVIewModel
	{
		private NomalComPageModel m;


		public NomalComPageModel NomalModel { get => m; set => m = value; }

		public NomalComPageViewModel()
		{
;
			// 初始化命令和其他属性  
		
		}
		public void SetRevent(FCT.ReciveMess Receve) { 
			NomalModel.SerialPort.REvent += Receve;

		}
		internal void StartCom(Button? startbtn, Button? stopbutton, GroupBox gp1)
		{
			MyTips.ShowTips(startbtn.FindForm(), Tipstype.Error, "串口打开出现异常", 2000);
			if (NomalModel.SerialPort.IsOpen)
			{
				MyTips.ShowTips(startbtn.FindForm(), Tipstype.Error, "串口已经打开了", 2000, true);
				startbtn.Enabled = false;
				return;
			}
			gp1.Enabled = false;
			startbtn.Enabled = false;

			Task.Factory.StartNew(() =>
			{
				try
				{
					NomalModel.SerialPort.Open();
					startbtn.Invoke(() =>
					{
						stopbutton.Enabled = true;
					});
				}
				catch (Exception)
				{
					MyTips.ShowTips(startbtn.FindForm(), Tipstype.Error, "串口打开出现异常", 2000, true);
					startbtn.Invoke(() =>
					{
						gp1.Enabled = true;

						startbtn.Enabled = true;
					});


				}
			});
		}

		internal void StopCom(Button? stopbutton, Button Startbtn, GroupBox gp1)
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
						gp1.Enabled = true;

						Startbtn.Enabled = true;
					});
				}
				catch (Exception)
				{
					MyTips.ShowTips(stopbutton.FindForm(), Tipstype.Error, "串口关闭出现异常", 2000, true);
					stopbutton.Invoke(() =>
					{
						stopbutton.Enabled = true;
						gp1.Enabled = false;

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
			string str16 = string.Join(" ", Encoding.Default.GetBytes(richTextBox_s.SelectedText));
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

		internal void Send16(RichTextBox richTextBox_s,Action<ByteMessage> cellback)
		{
			ByteMessage btm = null;
			Task.Factory.StartNew(() =>
			{
				try
				{
					var str16 = richTextBox_s.Text.ToBitArray();
				 btm= new ByteMessage() {  Data= str16,Time = DateTime.Now};
					NomalModel.SerialPort.Write(str16, 0, str16.Length);
					cellback?.Invoke(btm);
				}
				catch (Exception)
				{
					MyTips.ShowTips(richTextBox_s.FindForm(), Tipstype.Error, "转换出现异常，数字对16进制是否过大");
				
				}
			});
		}

	
		public override void Create()
		{
			NomalModel = new NomalComPageModel();

		}

		public override void Destroy()
		{
			
		}
	}
}
