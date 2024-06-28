
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using UpperComAutoTest.Model;
using UpperComAutoTest.MyControls;

namespace UpperComAutoTest.ModelView
{
	public  class NomalComPageViewModel
	{
		private NomalComPageModel m;

		
		public NomalComPageModel NomalModel { get => m; set =>  m= value; }
	
		public NomalComPageViewModel() {
			// 初始化命令和其他属性  
			NomalModel = new NomalComPageModel();


		}

		internal void StartCom(Button? startbtn, Button? stopbutton,GroupBox gp1)
		{
					MyTips.ShowTips(startbtn.FindForm(), Tipstype.Error, "串口打开出现异常", 2000);
			if (NomalModel.SerialPort.IsOpen)
			{
				MyTips.ShowTips(startbtn.FindForm(),Tipstype.Error,"串口已经打开了",2000,true);
				startbtn.Enabled = false;
				return;
			}
			gp1.Enabled = false;
			startbtn.Enabled = false;

			Task.Factory.StartNew(() => { 
				try
				{
					NomalModel.SerialPort.Open();
					startbtn.Invoke(() => {
						stopbutton.Enabled = true;
					});
				}
				catch (Exception)
				{
					MyTips.ShowTips(startbtn.FindForm(), Tipstype.Error, "串口打开出现异常", 2000, true);
					startbtn.Invoke(() => {
						gp1.Enabled =true;

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

			Task.Factory.StartNew(() => {
				try
				{
					NomalModel.SerialPort.Close();
					stopbutton.Invoke(() => {
						gp1.Enabled = true;

						Startbtn.Enabled = true;
					});
				}
				catch (Exception)
				{
					MyTips.ShowTips(stopbutton.FindForm(), Tipstype.Error, "串口关闭出现异常", 2000, true);
					stopbutton.Invoke(() => {
						stopbutton.Enabled = true;
						gp1.Enabled = false;

					});


				}
			});
		}
	}
}
