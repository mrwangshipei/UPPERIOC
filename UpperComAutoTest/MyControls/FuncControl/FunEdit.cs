using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpperComAutoTest.Entry.IEventFileModel.IMsgEvent;
using UpperComAutoTest.MyControls.FuncControl.TypeEdit;

namespace UpperComAutoTest.MyControls.FuncControl
{
	public partial class FunEdit : Form
	{
		public FunEdit()
		{
			InitializeComponent();
			comboBox1.DataSource = FuncFactoryCenter.Instance.GetFuncItemName();

		}
		MsgEventInterface msgeve;
		public MsgEventInterface MsgEve
		{
			get => msgeve; set
			{

				msgeve = value;
				ChangeType(value);
			}
		}
		private void ChangeType(MsgEventInterface MsgEve)
		{
			panel1.Controls.Clear();
			var ist = FuncFactoryCenter.Instance.CreatFuncControl(MsgEve);
			ist.Dock = DockStyle.Fill;
			panel1.Controls.Add(ist);

		}
		private void ChangeType(string MsgEve)
		{
			panel1.Controls.Clear();
			var instan = FuncFactoryCenter.Instance.CreatFuncControl(MsgEve);
			instan.Dock = DockStyle.Fill;
			panel1.Controls.Add(instan);
			this.MsgEve = instan.msg;

		}
		public FunEdit(MsgEventInterface msgeve)
		{
			InitializeComponent();
			comboBox1.DataSource = FuncFactoryCenter.Instance.GetFuncItemName();
			comboBox1.Text = FuncFactoryCenter.Instance.GetFactryName(msgeve);
			textBox1.Text = msgeve.Name;
		
			this.MsgEve = msgeve;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ChangeType(comboBox1.Text);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (panel1.Controls.Count == 0)
			{
				MyTips.ShowTips(this, Tipstype.Warn, "请选择类型");
				return;
			}
			else
			{
				msgeve.Name = textBox1.Text;

				DialogResult = DialogResult.OK;
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			msgeve.Name = textBox1.Text;
		}
	}
}
