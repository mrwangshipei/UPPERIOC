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
	public partial class FrmDialog : Form
	{
		public static DialogResult ShowDialog(Form parent,string msg,string title) {
			FrmDialog fm = new FrmDialog();
			fm.Text = title;
			fm.label1.Text = msg;
			fm.Owner = parent;
			var r = fm.ShowDialog(parent);
			return r;
		}

		public static DialogResult ShowDialog(string msg, string title)
		{
			FrmDialog fm = new FrmDialog();
			fm.Text = title;
			fm.label1.Text = msg;
			fm.TopMost = true;
			return fm.ShowDialog();
		}
		public FrmDialog()
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
