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
		public static string ShowDialog(Form parent,string title, string defaultv ="") {
			FrmInput fm = new FrmInput();
			fm.label4.Text = title;
			fm.textBox1.Text = defaultv;

			fm.Owner = parent;
			//fm.textBox1.Text = defaulttext;
			var r = fm.ShowDialog(parent);
			
			if (r != DialogResult.OK)
			{
				return null;
			}
			return fm.textBox1.Text;
		}
		public static string ShowDialog(string title,string defaultv)
		{
			FrmInput fm = new FrmInput();
			fm.label4.Text = title;
			fm.textBox1.Text = defaultv;
			var r = fm.ShowDialog();
			if (r != DialogResult.OK)
			{
				return null;
			}
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
