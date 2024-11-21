using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmControl.FrmBase
{
	public partial class FrmBaseForm : Form
	{
        public override string Text { get=> label1?.Text == null ? "": label1.Text; set {
				if (label1 == null)
				{
					return;
				}
			label1.Text = value; }
			} 
        public FrmBaseForm()
		{
			InitializeComponent();
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void apple3Btn1_Load(object sender, EventArgs e)
		{

		}
	}
}
