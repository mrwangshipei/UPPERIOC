using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMIEEE
{
	public partial class FrmPwd : Form
	{
		public static string[] Show(string title) {
			FrmPwd fm = new FrmPwd();
			fm.label4.Text = title;
			fm.TopMost = true;
			fm.ShowDialog();
			
			return new string[] {fm.textBox_un.Text,fm.textBoxpwd.Text };
		}
		public FrmPwd()
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
