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
		public MsgEventInterface MsgBody;
		public SelectFuncControl() { }
		public SelectFuncControl( MsgEventInterface MsgBody)
		{

			InitializeComponent();
			this.MsgBody = MsgBody;
			label1.Text = MsgBody.Name;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FunEdit fc = new FunEdit(MsgBody);
			var r = fc.ShowDialog();
			if (r == DialogResult.OK)
			{
				label1.Text = MsgBody.Name;
			   
			}
		}
	}
}
