using COMIEEE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpperComAutoTest.MyControls
{
	
	public partial class Loading : Form
	{
		public void SetMessage(string msg,int value) {

			if (InvokeRequired)
			{
			
				this.Invoke(new Action(() => {

					label1.Text = msg;
					gradientProgressBar1.Value = value;
					
				}));
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
		public void DoInvoke(Action act)
		{
			if (InvokeRequired)
			{
				this.Invoke(act);
			}
			else
			{
				act.Invoke();
			}
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Task.Factory.StartNew(() => {
				while (!Visible)
				{
					Thread.Sleep(20);
				}
				try
				{

					act.Invoke(this);
				}
				catch (Exception ex)
				{
					DoInvoke(()=>FrmDialog.ShowDialog(this,ex.Message+ex.StackTrace,"异常"));
					
				}

				if (Visible)
				{
					this.Invoke(new Action(() => { 
						Close();
					}));
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
				BaseForm.Invoke(new Action(() =>
				{
					ShowFormInvoke(BaseForm,act);
				}));
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
			BaseForm.BeginInvoke(new Action(() => {
				
				l.ShowDialog(BaseForm);
			}));

			
		}
	}
}
