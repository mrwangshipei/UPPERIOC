using COMIEEE;
using FrmBase_;
using FrmControl.Frm;
using FrmControl.FrmBase_;
using FrmControl.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpperComAutoTest.MyControls.Frm
{
	
	public partial class Loading : FrmBase
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
			MemoryStream stream = new MemoryStream(Resources.logo);
			
			this.Icon = new Icon(stream);
            // 定义矩形的位置和大小
            Rectangle rect = this.ClientRectangle;

            // 创建一个 GraphicsPath 对象，并添加圆角矩形
            GraphicsPath path = new GraphicsPath();
            int radius = 20; // 设置圆角半径
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // 左上角
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90); // 右上角
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90); // 右下角
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90); // 左下角
            path.CloseFigure(); // 关闭路径，完成矩形形状

            this.Region = new Region();

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
			BaseForm.BeginInvoke(new Action(() => {
				
				l.ShowDialog(BaseForm);
			}));

			
		}

        private void loadingControl1_Click(object sender, EventArgs e)
        {

			//MyTips.ShowTipSuccess(this,"没有Bug，没有Bug，没有Bug");
        }
    }
}
