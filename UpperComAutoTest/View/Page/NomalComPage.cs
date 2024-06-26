
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
using UpperComAutoTest.ModelView;
using UpperComAutoTest.View.Page.Interface;

namespace UpperComAutoTest.Page
{
	public partial class NomalComPage : IPage
	{
		public NomalComPage()
		{
			InitializeComponent();
			ViewModel = new NomalComPageViewModel();
			comboBox3.DataSource = Enum.GetNames(typeof(Parity));
			comboBox4.DataSource = Enum.GetNames(typeof(StopBits));
			comboBox1.DataSource = ViewModel.NomalModel.PortName;
			comboBox5.DataSource = ViewModel.NomalModel.DataBits;
			comboBox2.DataSource = ViewModel.NomalModel.Btv;

		}

		public override string PageName { get => Name; }
		public NomalComPageViewModel? ViewModel { get; set; }

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ViewModel.NomalModel.SerialPort.PortName = comboBox1.SelectedItem.ToString();
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			int.TryParse(comboBox2.SelectedItem.ToString(), out int btv);
			if (btv <= 0)
			{
				return;
			}
			ViewModel.NomalModel.SerialPort.BaudRate = btv;

		}

		private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
		{
			int.TryParse(comboBox5.SelectedItem.ToString(), out int db);
			if (db <= 0)
			{
				return;
			}
			ViewModel.NomalModel.SerialPort.DataBits = db;

		}

		private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Enum.TryParse(comboBox4.SelectedItem.ToString(), out StopBits stopBits))
			{
				ViewModel.NomalModel.SerialPort.StopBits = stopBits;

			}
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Enum.TryParse(comboBox3.SelectedItem.ToString(), out Parity stopBits))
			{
				ViewModel.NomalModel.SerialPort.Parity = stopBits;
			}
		}

		private void checkBox7_CheckedChanged(object sender, EventArgs e)
		{
			ViewModel.NomalModel.SerialPort.RtsEnable = checkBox7.Checked;

		}

		private void checkBox8_CheckedChanged(object sender, EventArgs e)
		{
			ViewModel.NomalModel.SerialPort.DtrEnable = checkBox8.Checked;

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Button startbtn = sender as Button;
			ViewModel.StartCom(startbtn, button3,groupBox1);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Button stopbutton = sender as Button;
			ViewModel.StopCom(stopbutton, button1, groupBox1);
		}
	}
}
