using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpperComAutoTest.MyControls
{
	public partial class MyTips : Form
	{
		public MyTips()
		{
			InitializeComponent();
		}
		public float radius { get; set; } = 15;
        public static List<MyTips> useing_Tips = new List<MyTips>();
		public static void ShowTips(Form BaseForm, Tipstype Type, string msg, int waittime = 2000, bool inWindow = true)
		{
			if (BaseForm.InvokeRequired)
			{
				BaseForm.Invoke(new Action(() => {
					ShowTip(BaseForm, Type, msg, waittime , inWindow);
				}));
			}
			else
			{
				ShowTip(BaseForm, Type, msg, waittime, inWindow);

			}
		}
		private static void ShowTip(Form BaseForm,Tipstype Type, string msg,int waittime = 2000,bool inWindow = true) 
		{
			lock (useing_Tips)
			{

			if (useing_Tips.Count > 0 && useing_Tips.Last().Visible)
			{
				useing_Tips.Last().CloseWindow(null,null);
			}
			MyTips tips = new MyTips();
		
			switch (Type)
			{
				case Tipstype.Warn:
					tips.BackColor = Color.DimGray;
					break;
				case Tipstype.Success:
					tips.BackColor = Color.LightGreen;

					break;
				case Tipstype.Tip:
					tips.BackColor = Color.LightGray;

					break;
				case Tipstype.Error:
					tips.BackColor = Color.IndianRed;

					break;
				default:
					break;
			}
				tips.label2.ImageIndex = (int)Type;
			tips.label1.Text = msg;
				tips.TopMost = true;
			useing_Tips.Add(tips);
				tips.StartPosition = FormStartPosition.Manual;
				if (inWindow)
				{
					tips.Location = new Point(BaseForm.Location.X+ (BaseForm.Width /2 - tips.Width /2), BaseForm.Location.Y + (BaseForm.Height - tips.Height - 200));
				}
				else
				{
					tips.Location = new Point(Screen.PrimaryScreen.Bounds.Location.X + (Screen.PrimaryScreen.Bounds.Width / 2 - tips.Width / 2), Screen.PrimaryScreen.Bounds.Location.Y + (Screen.PrimaryScreen.Bounds.Height - tips.Height - 220));

				}
				tips.ShowForm(waittime);
			}

		}
		System.Windows.Forms.Timer close_t = new System.Windows.Forms.Timer();

		private void ShowForm(int waittime = 2000)
		{
			Show();
			Rectangle rect = this.ClientRectangle;
			GraphicsPath pa = new GraphicsPath();
			// 开始绘制圆角矩形  
			// 注意：为了简化，我们假设矩形的宽度和高度都足够大，可以放下圆角  

			// 左上角  
			pa.AddArc(rect.Left, rect.Top, 2 * radius, 2 * radius, 180, 90);

			// 右上角  
			pa.AddArc(rect.Right - 2 * radius, rect.Top, 2 * radius, 2 * radius, 270, 90);

			// 右下角 
			pa.AddArc(rect.Right - 2 * radius, rect.Bottom - 2 * radius, 2 * radius, 2 * radius, 0, 90);

			// 左下角 
			pa.AddArc(rect.Left, rect.Bottom - 2 * radius, 2 * radius, 2 * radius, 90, 90);

			this.Region = new Region(pa);
			close_t.Interval = waittime;
			close_t.Tick += CloseWindow;
			close_t.Enabled = true;
		}

		private void CloseWindow(object sender, EventArgs e)
		{
			close_t.Enabled = false;
			this.Visible = false;
		}
	}
	public enum Tipstype
	{
		Tip,Warn,Error,Success
	}
}
