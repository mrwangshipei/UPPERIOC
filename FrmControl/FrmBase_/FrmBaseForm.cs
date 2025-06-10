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
using FrmControl.Util;

namespace FrmControl.FrmBase_
{
	public partial class FrmBaseForm : FrmBase
	{
        public override string Text { get=> label1?.Text == null ? "": label1.Text; set {
				if (label1 == null)
				{
					return;
				}
			label1.Text = value; }
			}
		public bool showicon = false;
        public bool ShowIcon { get=> showicon; set {
				showicon = value;
				LoadImg();
			
			}
		}
        public FrmBaseForm()
		{
			InitializeComponent();
            SetMove();
			LoadImg();
            SetGradientBackground(panel2,Color.Black,Color.LightGray);
        }

        private void SetMove()
        {
            MoveShiJianEvent move  = new MoveShiJianEvent();
			move.BangDingMove(panel1,this);
			move.BangDingMove(apple3Btn1,this);
			move.BangDingMove(label1,this);
			move.BangDingMove(pictureBox_Logo,this);
		}

        public static void SetGradientBackground(Control control, Color color1, Color color2)
        {
            control.Paint += (s, e) =>
            {
				if (control.ClientRectangle.Width == 0 || control.ClientRectangle.Height == 0) {
					return;
				}
                using (LinearGradientBrush brush = new LinearGradientBrush(
                control.ClientRectangle, color1, color2, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, control.ClientRectangle);
                }
            };

            control.Invalidate(); // 触发重绘
        }
        

        public void DoInvoke(Action act) {
			if (InvokeRequired)
			{
				Invoke(act);
			}
			else
			{
				act.Invoke();
			}

		}
        private void LoadImg()
        {
			if (!ShowIcon)
			{
				this.pictureBox_Logo.Image = null;
				this.pictureBox_Logo.Width = 0;
				return;
            }
            var p = AppDomain.CurrentDomain.BaseDirectory + "/Data/img/MainForm.png";
            FileInfo f = new FileInfo(p);
			if (f.Exists)
			{
				this.pictureBox_Logo.Image = Image.FromFile(f.FullName);
				if (this.pictureBox_Logo.Image.Width > 0 && this.pictureBox_Logo.Image.Height > 0)
				{
					this.pictureBox_Logo.Width = this.pictureBox_Logo.Height * (this.pictureBox_Logo.Image.Width / this.pictureBox_Logo.Image.Height);
				}
			}
			else {
                this.pictureBox_Logo.Image = Properties.Resources.UPPERIOC;
                if (this.pictureBox_Logo.Image.Width > 0 && this.pictureBox_Logo.Image.Height > 0)
                {
                    this.pictureBox_Logo.Width = this.pictureBox_Logo.Height * (this.pictureBox_Logo.Image.Width / this.pictureBox_Logo.Image.Height);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void apple3Btn1_Load(object sender, EventArgs e)
		{

		}
	}
}
