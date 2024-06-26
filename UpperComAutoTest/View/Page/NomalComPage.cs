
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
			comboBox3.DataSource = Enum.GetNames(typeof(Parity));
			comboBox4.DataSource = Enum.GetNames(typeof(StopBits));

		}

		public override string PageName { get => Name; }
		public NomalComPageViewModel? ViewModel { get; set; }

	
	}
}
