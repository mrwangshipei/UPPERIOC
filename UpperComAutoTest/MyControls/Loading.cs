using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpperComAutoTest.MyControls
{
	
	public partial class Loading : Form
	{
		public void SetMessage(string msg,int value) {

			if (InvokeRequired)
			{
			
				this.Invoke(() => {

					label1.Text = msg;
					gradientProgressBar1.Value = value;
					
				});
			}
			else
			{
				label1.Text = msg;
				gradientProgressBar1.Value = value;
				
			}
			
		}
		public Loading(Action<Loading> act)
		{

			this.act = act;
			InitializeComponent();

		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Task.Factory.StartNew(() => {
				while (!Visible)
				{
					Thread.Sleep(20);
				}
				act.Invoke(this);

				if (Visible)
				{
					this.Invoke(() => { 
						Close();
					});
				}
			});
		}
		Action<Loading> act;
		/// <summary>
		/// 打开加载框
		/// </summary>
		/// <param name="BaseForm">主窗体</param>
		/// <param name="act">异步任务</param>
		public static void ShowForm(Form BaseForm, Action<Loading> act)
		{
			if (BaseForm.InvokeRequired)
			{
				BaseForm.Invoke(() =>
				{
					ShowFormInvoke(BaseForm,act);
				});
			}
			else
			{
				ShowFormInvoke(BaseForm, act);

			}
		}
		/// <summary>
		/// 必须2在主线程执行2
		/// </summary>
		/// <param name="act"></param>

		private static void ShowFormInvoke(Form BaseForm, Action<Loading> act)
		{
			Loading l = new Loading(act);
			bool start = false;
			BaseForm.BeginInvoke(() => {
				
				l.ShowDialog(BaseForm);
			});

			
		}
	}
}
