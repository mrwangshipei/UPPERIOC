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
		public Apple3Btn()
		{
			InitializeComponent();
			
			this.Margin = new Padding(0, 0, 0, 0);
			this.Padding = new Padding(0, 0, 0, 0);
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
	}
}
