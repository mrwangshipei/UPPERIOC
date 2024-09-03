using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMIEEE
{
	public partial class FrmInput : Form
	{
		public static string ShowDialog(Form parent,string title) {
			FrmInput fm = new FrmInput();
			fm.label4.Text = title;
			fm.Owner = parent;
			var r = fm.ShowDialog(parent);
			return fm.textBox1.Text;
		}
		public FrmInput()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void panel5_Paint(object sender, EventArgs e)
		{
			this.Close();

		}
	}
}
