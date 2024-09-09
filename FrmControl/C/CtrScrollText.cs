using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpperComAutoTest.MyControls;

namespace FrmControl.C
{
	public partial class CtrScrollText : UserControl
	{
		private float nowP = 0;
		private int radius = 10;
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public new string FText { get=>base.Text; set => base.Text = value; }
        public int Radius
		{
			get { return radius; }
			set { radius = value; }
		}

		private bool autoclose;

		public bool AutoClose
		{
			get { return autoclose; }
			set { autoclose = value; }
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

		public Color BackColor { get; set; }
        private Color back;

		public Color BColor
		{
			get { return back; }
			set { back = value; }
		}

		private float speed = 1;
		int regionr = 0;
		public float Speed
		{
			get { return speed; }
			set { speed = value; }
		}
		CancellationToken ct;
		public CtrScrollText()
		{
			ct = new System.Threading.CancellationToken();
			SetStyle( ControlStyles.UserPaint, true);
			SetStyle( ControlStyles.SupportsTransparentBackColor, true);
			DoubleBuffered = true;
			BackColor = Color.Transparent;
			ForeColor = Color.Red;
			BColor = Color.Black;
			Font = new Font("幼圆", 11);
			Task.Factory.StartNew(() =>
			{
				while (true)
				{
					while (this.Visible)
					{
						nowP += Speed;
						if (nowP > Width)
						{
							nowP = 0;
						}
						this.Invalidate();
						Thread.Sleep(20);
					}

					Thread.Sleep(20);
				}
			},ct );
		}
		protected override void OnHandleDestroyed(EventArgs e)
		{
			base.OnHandleDestroyed(e);
			ct.ThrowIfCancellationRequested();
		}
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			if (AutoClose)
			{
				MyTips.ShowTips(this.FindForm(),Tipstype.Tip,"提示将在三秒后关闭");
				Task.Factory.StartNew(() => {
					Thread.Sleep(3000);
					Invoke(new Action(() => { 
						this.Visible = false;
					}));
				});
			}

		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			var g = e.Graphics;
			base.OnPaint(e);

			// 设置抗锯齿效果  
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			// 创建一个矩形，其大小与控件相同  
			Rectangle rect = this.ClientRectangle;

			// 创建一个GraphicsPath对象，用于绘制圆角矩形  
			GraphicsPath path = new GraphicsPath();

			// 添加圆角矩形的四个角  
			path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90);
			path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
			path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
			path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90);
			if (regionr != radius)
			{
				regionr = radius;
				this.Region = new Region(path);

			}
			// 封闭路径  
			path.CloseFigure();

			// 使用路径来填充和绘制圆角矩形  
			// 填充颜色可以根据需要自定义  
			using (Brush brush = new SolidBrush(this.BColor))
			{
				e.Graphics.FillPath(brush, path);
			}
			var s = g.MeasureString(FText, Font);
			var point = new PointF(nowP, (Height - s.Height)/2);
			g.DrawString(FText, Font,new SolidBrush(this.ForeColor),point);
		}
	}
}
