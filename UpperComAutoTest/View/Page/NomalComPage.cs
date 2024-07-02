
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
using UpperComAutoTest.MyControls;
using UpperComAutoTest.SendorEvent;
using UpperComAutoTest.View.Page.Interface;

using UPPERIOC.Interface;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.Sendor;

namespace UpperComAutoTest.Page
{
	[IOCObject]
	public partial class NomalComPage : IPage
	{
#if DESIGNER
		
#endif
		public NomalComPage() : base()
		{

		}
		[IOCConstructor]

		public NomalComPage(NomalComPageViewModel viewm) : base(viewm)
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
			Sendor.Register<AutoRefeashEvent>((ato) => {
				this.Invoke(() => { 
					ComViewMOdel.ReceveTo16(ComViewMOdel.NomalModel.Receve16x, richTextBox_r);
				});

			});
		}


		private void ReceverEvent(ByteMessage Reciver)
		{
			var str = Reciver.ByteDataToStr(ComViewMOdel.NomalModel.Receve16x, ComViewMOdel.NomalModel.Timestamp, true);
			this.Invoke(() =>
			{
				richTextBox_r.AppendText(str);
			});
		}

		public override string PageName { get => Name; }

		public NomalComPageViewModel? ComViewMOdel { get => (NomalComPageViewModel)(ViewModel); set => ViewModel = value; }

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
			ComViewMOdel.StartCom(startbtn, button3, (success) =>
			{
				if (success)
				{
					groupBox1.Enabled = false;
					startbtn.Enabled = false;
					button3.Enabled = true;
					groupBox4.Enabled = true;

				}

			});
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Button stopbutton = sender as Button;
			ComViewMOdel.StopCom(stopbutton, button1, (success) =>
			{
				if (success)
				{
					groupBox1.Enabled = true;
					button1.Enabled = true;
					button3.Enabled = false;
					groupBox4.Enabled = false;

				}

			});
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
			ComViewMOdel.Send16( btm =>
			{
				this.Invoke(() =>
				{
					if (btm.Err != null)
					{
						MyTips.ShowTips(richTextBox_s.FindForm(), Tipstype.Error, btm.Err.Message);
						return;
					}
					richTextBox_r.AppendText(btm.ByteDataToStr(ComViewMOdel.NomalModel.Receve16x, ComViewMOdel.NomalModel.Timestamp, false));
				});
			});
		}


		private void checkBox5_CheckedChanged(object sender, EventArgs e)
		{
			ComViewMOdel.NomalModel.Timestamp = checkBox5.Checked;
			ComViewMOdel.ReceveTo16(ComViewMOdel.NomalModel.Receve16x, richTextBox_r);

		}

		private void 转16进制ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ComViewMOdel.ChangeSelectionTo16x(richTextBox_s);
		}

		private void 查看字符ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ComViewMOdel.ChangeSelectionTostring(richTextBox_s);

		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			ComViewMOdel.SetBlackBackGroud(checkBox2.Checked, (success) =>
			{
				if (success)
				{
					this.Invoke(() =>
					{
						if (checkBox2.Checked)
						{
							richTextBox_r.BackColor = Color.Black;
							richTextBox_r.ForeColor = Color.White;

						}
						else
						{
							richTextBox_r.BackColor = Color.White;
							richTextBox_r.ForeColor = Color.Black;

						}
					});
				}
			});
		}

		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			ComViewMOdel.AutoSend = checkBox3.Checked;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			ComViewMOdel.ClearReceive((success) =>
			{
				this.Invoke(() =>
				{
					if (success)
					{
						richTextBox_r.Clear();

					}
					ComViewMOdel.ReceveTo16(ComViewMOdel.NomalModel.Receve16x, richTextBox_r);
				});
			});
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(textBox1.Text, out int value))
			{
				ComViewMOdel.AutoSendTime = value;
			}


		}

		private void richTextBox_s_TextChanged(object sender, EventArgs e)
		{
			ComViewMOdel.NomalModel.SendMsg = richTextBox_s.Text;
		}
		
	}
}
