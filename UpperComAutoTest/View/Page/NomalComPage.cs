
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpperComAutoTest.Entry;
using UpperComAutoTest.Extend;
using UpperComAutoTest.ModelView;
using UpperComAutoTest.ModelView._IViewModel;
using UpperComAutoTest.View.Page.Interface;

namespace UpperComAutoTest.Page
{
	public partial class NomalComPage : IPage
	{
		public NomalComPage(IVIewModel viewm) : base(viewm)
		{
			;
			InitializeComponent();
			ComViewMOdel = viewm as NomalComPageViewModel; 
			ComViewMOdel.SetRevent(ReceverEvent);
			comboBox3.DataSource = Enum.GetNames(typeof(Parity));
			comboBox4.DataSource = Enum.GetNames(typeof(StopBits)).Where(r => r != "None").ToList();
			comboBox1.DataSource = ComViewMOdel.NomalModel.PortName;
			comboBox5.DataSource = ComViewMOdel.NomalModel.DataBits;
			comboBox2.DataSource = ComViewMOdel.NomalModel.Btv;
		}

	
		private void ReceverEvent(ByteMessage Reciver)
		{
			var str = Reciver.ByteDataToStr(ComViewMOdel.NomalModel.Receve16x, ComViewMOdel.NomalModel.Timestamp,true);
			this.Invoke(() =>
			{
				richTextBox_r.AppendText(str);
			});
		}

		public override string PageName { get => Name; }

		public NomalComPageViewModel? ComViewMOdel { get=> (NomalComPageViewModel)(ViewModel); set=> ViewModel = value; }

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComViewMOdel.NomalModel.SerialPort.PortName = comboBox1.SelectedItem.ToString();
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			int.TryParse(comboBox2.SelectedItem.ToString(), out int btv);
			if (btv <= 0)
			{
				return;
			}
			ComViewMOdel.NomalModel.SerialPort.BaudRate = btv;

		}

		private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
		{
			int.TryParse(comboBox5.SelectedItem.ToString(), out int db);
			if (db <= 0)
			{
				return;
			}
			ComViewMOdel.NomalModel.SerialPort.DataBits = db;

		}

		private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Enum.TryParse(comboBox4.SelectedItem.ToString(), out StopBits stopBits))
			{
				ComViewMOdel.NomalModel.SerialPort.StopBits = stopBits;

			}
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Enum.TryParse(comboBox3.SelectedItem.ToString(), out Parity stopBits))
			{
				ComViewMOdel.NomalModel.SerialPort.Parity = stopBits;
			}
		}

		private void checkBox7_CheckedChanged(object sender, EventArgs e)
		{
			ComViewMOdel.NomalModel.SerialPort.RtsEnable = checkBox7.Checked;

		}

		private void checkBox8_CheckedChanged(object sender, EventArgs e)
		{
			ComViewMOdel.NomalModel.SerialPort.DtrEnable = checkBox8.Checked;

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Button startbtn = sender as Button;
			ComViewMOdel.StartCom(startbtn, button3, groupBox1);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Button stopbutton = sender as Button;
			ComViewMOdel.StopCom(stopbutton, button1, groupBox1);
		}

		private void checkBox6_CheckedChanged(object sender, EventArgs e)
		{
			//	ViewModel.NomalModel.Send16x = checkBox6.Checked;
			//	ViewModel.SendTo16(ViewModel.NomalModel.Send16x, richTextBox_s);

		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			ComViewMOdel.NomalModel.Receve16x = checkBox1.Checked;
			ComViewMOdel.ReceveTo16(ComViewMOdel.NomalModel.Receve16x, richTextBox_r);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ComViewMOdel.Send16(richTextBox_s, btm => {
				richTextBox_r.AppendText(btm.ByteDataToStr(ComViewMOdel.NomalModel.Receve16x, ComViewMOdel.NomalModel.Timestamp,false));
			});
		}
		

		private void checkBox5_CheckedChanged(object sender, EventArgs e)
		{
			ComViewMOdel.NomalModel.Timestamp = checkBox5.Checked;

		}

		private void 转16进制ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ComViewMOdel.ChangeSelectionTo16x(richTextBox_s);
		}

		private void 查看字符ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ComViewMOdel.ChangeSelectionTostring(richTextBox_s);

		}
	}
}
