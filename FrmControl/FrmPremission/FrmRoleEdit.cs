using COMIEEE.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPPERIOC2.UPPER.Premission.Model;

namespace FrmControl.FrmPremission
{
	public partial class FrmRoleEdit : Form
	{
		public Role Backupr;
		public FrmRoleEdit(Role ur)
		{
			InitializeComponent();
			Backupr = Deepcopy.DeepCopy(ur);
			InitRole(Backupr);
		}

		public FrmRoleEdit()
		{
			InitializeComponent();

			Backupr = new Role();
		}

		private void InitRole(Role backupr)
		{
			textBox1.Text = backupr.id+"";
			textBox2.Text = backupr.Name;
			textBox3.Text = backupr.Backup;

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			Backupr.Backup = textBox3.Text ;

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			Backupr.Name = textBox2.Text;

		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
