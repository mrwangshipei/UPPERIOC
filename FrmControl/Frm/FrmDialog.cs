using System;

using System.Windows.Forms;
using FrmControl.FrmBase_;

namespace FrmBase_
{
	public partial class FrmDialog : FrmBaseForm
	{
		public static DialogResult ShowDialog(Form parent,string msg,string title) {
			FrmDialog fm = new FrmDialog();
			fm.Text = title;
			fm.label11.Text = msg;
			fm.Owner = parent;
			var r = fm.ShowDialog(parent);
			return r;
		}

		public static DialogResult ShowDialog(string msg, string title)
		{
			FrmDialog fm = new FrmDialog();
			fm.Text = title;
			fm.label11.Text = msg;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
