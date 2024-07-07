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

namespace UpperComAutoTest.MyControls.FuncControl
{
	public partial class SelectFuncControl : UserControl
	{
		internal string Funname;
		internal MsgEventInterface MsgBody;
		public SelectFuncControl() { }
		public SelectFuncControl(string Funname, MsgEventInterface MsgBody)
		{
			InitializeComponent();
			this.Funname = Funname;
			this.MsgBody = MsgBody;
			label1.Text = Funname;
		}
	}
}
