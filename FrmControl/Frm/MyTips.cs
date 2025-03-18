using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FrmControl.Frm
{
	public partial class MyTips : Form
	{
		public MyTips()
		{
			InitializeComponent();
			ShowInTaskbar = false;
            FormClosed += MyTips_FormClosed;

        }
		public float radius { get; set; } = 15;
        public int _ImageIndex;
        public int ImageIndex { get=>_ImageIndex; set {
                _ImageIndex = value;
                Invalidate();
            } }

        public static List<MyTips> useing_Tips = new List<MyTips>();
		public static void ShowTips(Form BaseForm, Tipstype Type, string msg, int waittime = 2000, bool inWindow = true)
		{
            if (BaseForm != null && BaseForm.InvokeRequired)
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
		public static void ShowTips(Tipstype Type, string msg, int waittime = 2000)
		{
			ShowTips(null, Type, msg, waittime, false);

        }
        /// <summary>
        /// 显示成功提示（独立窗口，无父窗体关联）
        /// </summary>
        public static void ShowTipSuccess(string message, int waitTime = 2000)
        {
            ShowTip(null, Tipstype.Success, message, waitTime, inWindow: false);
        }

        /// <summary>
        /// 显示信息提示（独立窗口，无父窗体关联）
        /// </summary>
        public static void ShowTipTip(string message, int waitTime = 2000)
        {
            ShowTip(null, Tipstype.Tip, message, waitTime, inWindow: false);
        }

        /// <summary>
        /// 显示警告提示（独立窗口，无父窗体关联）
        /// </summary>
        public static void ShowTipWarn(string message, int waitTime = 2000)
        {
            ShowTip(null, Tipstype.Warn, message, waitTime, inWindow: false);
        }

        /// <summary>
        /// 显示错误提示（独立窗口，无父窗体关联）
        /// </summary>
        public static void ShowTipError(string message, int waitTime = 2000)
        {
            ShowTip(null, Tipstype.Error, message, waitTime, inWindow: false);
        }
        // 扩展调用方法 
        /// <summary>
        /// 显示调试类提示 
        /// </summary>
        /// <param name="baseForm">承载提示窗体的父容器</param>
        /// <param name="message">提示信息内容</param>
        /// <param name="waitTime">提示持续时长(ms)，默认2000ms</param>
        /// <param name="inWindow">是否在窗体内部显示，默认true</param>
        public static void ShowTipSuccess(Form baseForm, string message, int waitTime = 2000, bool inWindow = true)
        {
            ShowTip(baseForm, Tipstype.Success, message, waitTime, inWindow);
        }

        /// <summary>
        /// 显示信息类提示 
        /// </summary>
        public static void ShowTipTip(Form baseForm, string message, int waitTime = 2000, bool inWindow = true)
        {
            ShowTip(baseForm, Tipstype.Tip, message, waitTime, inWindow);
        }

        /// <summary>
        /// 显示警告类提示 
        /// </summary>
        public static void ShowTipWarn(Form baseForm, string message, int waitTime = 2000, bool inWindow = true)
        {
            ShowTip(baseForm, Tipstype.Warn, message, waitTime, inWindow);
        }

        /// <summary>
        /// 显示错误类提示 
        /// </summary>
        public static void ShowTipError(Form baseForm, string message, int waitTime = 2000, bool inWindow = true)
        {
            ShowTip(baseForm, Tipstype.Error, message, waitTime, inWindow);
        }
        private static void ShowTip(Form BaseForm,Tipstype Type, string msg,int waittime = 2000,bool inWindow = true) 
		{
		
                if (BaseForm != null && BaseForm.InvokeRequired)
                {
                    BaseForm.Invoke(ShowTip, BaseForm, Type, msg, waittime, inWindow);
                    return;
                }
                else if (BaseForm == null)
                {
                    if (Application.OpenForms.Count > 0 && Application.OpenForms[0].InvokeRequired)
                    {
                        Application.OpenForms[0].Invoke(ShowTip, Application.OpenForms[0], Type, msg, waittime, inWindow);
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                lock (useing_Tips)
                {
                    if (useing_Tips.Count > 0 && useing_Tips.Last().Visible)
		            {
			            useing_Tips.Last().CloseWindow(null,null);
		            }
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
				tips.ImageIndex = (int)Type;
			    tips.label1.Text = msg;
				tips.TopMost = true;
                lock (useing_Tips)
                { 
                    useing_Tips.Add(tips);
                }
				tips.StartPosition = FormStartPosition.Manual;
				if (inWindow)
				{
					tips.Location = new Point(BaseForm.Location.X+ (BaseForm.Width /2 - tips.Width /2), BaseForm.Location.Y + (BaseForm.Height - tips.Height - (int)(BaseForm.Height *0.25) ));
				}
				else
				{
					tips.Location = new Point(Screen.PrimaryScreen.Bounds.Location.X + (Screen.PrimaryScreen.Bounds.Width / 2 - tips.Width / 2), Screen.PrimaryScreen.Bounds.Location.Y + (Screen.PrimaryScreen.Bounds.Height - tips.Height - 220));

				}
				int n = tips.GetTextLineCount(tips.label1);
				tips.Height = tips.Height * n;
				tips.ShowForm(waittime);

		}
   
        public int GetTextLineCount(System.Windows.Forms.Label label1)
	{
		using (Graphics graphics = label1.CreateGraphics())
		{
			SizeF textSize = graphics.MeasureString(label1.Text, label1.Font);
			int lineCount = (int)Math.Ceiling(textSize.Width / label1.Width);

			return lineCount;
		}
	}
	System.Windows.Forms.Timer close_t = new System.Windows.Forms.Timer();

        private void ShowForm(int waittime = 2000)
        {
            // 确保从主线程访问
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int>(ShowForm), waittime);  // 调用主线程上的方法
                return;
            }

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
            Task.Factory.StartNew(() => { 
               Thread.Sleep(waittime);
               CloseWindow(null,null);
            });
          /*  close_t.Interval = waittime;
            close_t.Tick += CloseWindow;
            close_t.Enabled = true;*/
        }
        private void MyTips_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }
        private void CloseWindow(object sender, EventArgs e)
		{
            //close_t.Enabled = false;
            if (InvokeRequired)
            {
                Invoke(CloseWindow,null,null);
                return;
            }
			this.Visible = false;
		}

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            // 获取图像列表中的图像
            Image image = imageList1.Images[ImageIndex]; // 根据需要选择图像索引
            
            // 获取 Panel 的大小
            int panelWidth = panel3.Width;
            int panelHeight = panel3.Height;
            // 计算正方形的高度（宽度是高度的三分之二）
            int squareHeight = 35;

            // 计算正方形的左上角坐标，使其居中
            int x = (panelWidth - squareHeight) / 2;
            int y = (panelHeight - squareHeight) / 2;
            var g = e.Graphics;
            // 计算目标矩形的大小和位置
            Rectangle destRect = new Rectangle(x,y, squareHeight, squareHeight);
         
            // 设置抗锯齿模式

            // 绘制图像，缩放以适应 Panel 的大小
            e.Graphics.DrawImage(image, destRect);
        }

    }
   
}
