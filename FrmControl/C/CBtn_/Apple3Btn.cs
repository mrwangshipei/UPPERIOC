using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmControl.C.Btn
{
	public partial class Apple3Btn : UserControl
	{
		public Padding _btnPad;
        public Padding BtnPad { get=> panel1.Padding;
            set {
				panel1.Padding = value;
				panel2.Padding = value;
				panel3.Padding = value;
				_btnPad = value;
			}
		}
        public Apple3Btn()
		{
            InitializeComponent();
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint|ControlStyles.SupportsTransparentBackColor, true);
		
		}

		private void frmBtn1_Click(object sender, EventArgs e)
		{
			this.FindForm().WindowState = FormWindowState.Minimized;
		}

		private void frmBtn3_Click(object sender, EventArgs e)
		{
			this.FindForm().Close();
		}

		private void frmBtn2_Click(object sender, EventArgs e)
		{
			if (this.FindForm().WindowState == FormWindowState.Maximized)
			{
				this.FindForm().WindowState = FormWindowState.Normal;
			}
			else
			{
				this.FindForm().WindowState = FormWindowState.Maximized;
			}

		}

		private void Apple3Btn_SizeChanged(object sender, EventArgs e)
		{
		//	this.frmBtn1.Radius = this.frmBtn1.Width / 2;
			//this.frmBtn2.Radius = this.frmBtn2.Width / 2;
		//	this.frmBtn3.Radius = this.frmBtn3.Width / 2;
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
