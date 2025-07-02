using FCT.MyControls;
using FrmControl.C.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmControl.C.Btn
{
    public class FrmBtn : CBaseControl
	{
        // 默认背景颜色
        public Color defaultBackColor { 
			get => defaultBackColor1; 
			set 
			{ 
				defaultBackColor1 = value;
				this.BackColor = value;
                this.Invalidate();

            }
        }         // 鼠标悬停时的背景颜色
		public Color hoverBackColor { get; set; } = Color.LightGray;
		// 鼠标按下时的背景颜色
		public Color pressedBackColor { get; set; } = Color.Gray;

        public float smallimg { get => smallimg1; set { smallimg1 = value; 
			this.Invalidate();

            }
        }
        public float BorderWidth { get => borderWidth; set {borderWidth = value; 
			this.Invalidate();
            }
        }
        public Color BorderColor { get => borderColor; set{ borderColor = value;
			this.Invalidate();

            }
        }
        public string FrmText { get => frmText; set{  frmText = value; 
			this.Invalidate();
			} }
        public Image BackImg { get; set; }
		public float ImgPix { get; set; } = 0f;
		private float lastell;
		public float ell;
		private bool IsMouseDown;
        public bool Issquare { get; set; }
        public float Radius { get { return ell; } set { ell = value;Invalidate(); } }
        public FrmBtn()
        {
            // 启用双缓冲和透明背景
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.SupportsTransparentBackColor, true);
        }
        private Rectangle Lastr;
        private Color defaultBackColor1 = Color.White;
        private string frmText;
        private float borderWidth = 1;
        private Color borderColor = Color.Black;
        private float smallimg1 = 1;

        protected override void OnPaint(PaintEventArgs e)
		{
			if (Radius != lastell || !Rectangle.Equals(this.ClientRectangle, Lastr))
			{
				if (Region != null)
				{
					Region.Dispose();
				}
				Lastr = this.ClientRectangle;
				lastell = Radius;
                this.Region = new Region(GraphicsExtensions.GetRoundedRectangle(this.ClientRectangle, Radius));
			}
           // base.OnPaint(e);

            var gp = e.Graphics;
			using (var bs = new SolidBrush(BackColor))
			{

				gp.FillPath(bs, GraphicsExtensions.GetRoundedRectangle(this.ClientRectangle, Radius));
			}
			gp.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			gp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			if (BackImg != null)
			{
				int x = (int)((Height - Height * smallimg)/ 2);
				int y = (int)((Width- Width* smallimg)/2);
				int Wid = (int)(Width * smallimg);
				int Hei= (int)(Height* smallimg);
				gp.DrawImage(BackImg,x,y,Wid,Hei);
			}
			var s  = gp.MeasureString(FrmText, Font);
			float fontsta = Width * ImgPix;
			float center = ((Width - fontsta) - s.Width)/2+fontsta;
			if (center < fontsta)
			{
				center = fontsta;
			}
			gp.DrawString(FrmText, Font,new SolidBrush(ForeColor),center, (Height - s.Height) /2);
			if (BorderWidth != 0)
			{

				var path  = GraphicsExtensions.GetRoundedRectangle(new Rectangle((int)(this.ClientRectangle.X + BorderWidth / 2), (int)(this.ClientRectangle.Y + (BorderWidth / 2)), (int)(this.ClientRectangle.Width - BorderWidth), (int)(this.ClientRectangle.Height - BorderWidth)), Radius);
				gp.DrawPath(new Pen(BorderColor, BorderWidth ),path); ;
			

			}
		}
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
			FrmText = Text;
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (Radius != lastell || !Rectangle.Equals(this.ClientRectangle, Lastr))
            {
                if (Region != null)
                {
                    Region.Dispose();
                }
                Lastr = this.ClientRectangle;
                this.Region = new Region(GraphicsExtensions.GetRoundedRectangle(this.ClientRectangle, Radius));
                lastell = Radius;
            }
        }
        protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (Issquare && this.Width != Height)
			{
				Width = Height;
				Radius = Width / 2;
			}
	//		this.Region = new Region(GraphicsExtensions.GetRoundedRectangle(this.ClientRectangle, Radius));
			//
		}

		// 鼠标进入控件时触发
		protected override void OnMouseEnter(EventArgs e)
		{
			if (this.IsDisposed)
			{
				return;
			}
			// 改变背景颜色为悬停颜色
			this.BackColor = hoverBackColor;
			base.OnMouseEnter(e);
		}

		// 鼠标离开控件时触发
		protected override void OnMouseLeave(EventArgs e)
		{
			if (this.IsDisposed)
			{
				return;
			}
			// 恢复背景颜色为默认颜色（如果当前不是按下状态）
			if (!this.IsMouseDown)
			{
				this.BackColor = defaultBackColor;
			}
			base.OnMouseLeave(e);

		}

		// 鼠标按下时触发
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (this.IsDisposed)
			{
				return;
			}
			// 改变背景颜色为按下颜色
			this.BackColor = pressedBackColor;
			base.OnMouseDown(e);
			IsMouseDown = true;
		}
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            // 每次位置变化，就更新 Region 保证圆角
          //  this.Region = new Region(GraphicsExtensions.GetRoundedRectangle(this.ClientRectangle, Radius));
        }

        // 鼠标释放时触发
        protected override void OnMouseUp( MouseEventArgs e)
		{
			if (this.IsDisposed)
			{
				return; 
			}
            IsMouseDown = false;

            // 恢复背景颜色为默认颜色（如果鼠标仍在控件内）
            if (this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
			{
				this.BackColor = hoverBackColor; // 或者根据需求恢复为默认颜色或其他颜色
			}
			// 注意：这里有个逻辑判断，如果鼠标释放时不在控件内，则不需要改变颜色，因为MouseLeave会处理
			base.OnMouseUp(e);

		}
	}
}
