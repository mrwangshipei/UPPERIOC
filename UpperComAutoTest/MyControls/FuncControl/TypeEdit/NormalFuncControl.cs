using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpperComAutoTest.Entry.IEventFileModel.IMsgEvent;
using UpperComAutoTest.Extend;

namespace UpperComAutoTest.MyControls.FuncControl.TypeEdit
{
	public partial class NormalFuncControl : IFuncTypeEdit
	{
		internal override MsgEventInterface msg { get => base.msg; set => base.msg = value; }

		private NormalFuncEvent Func { get => msg as NormalFuncEvent; set => msg = value; }
		internal NormalFuncControl()
		{
			InitializeComponent();

		}
		internal NormalFuncControl(NormalFuncEvent Func)
		{
			InitializeComponent();
			this.Func = Func;
		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{
			Func.Receivebytemess = new Entry.ByteMessage() { Data = richTextBox1.Text.ToBitArray(), IsSend = false, Time = DateTime.Now }; ;
		}

		private void richTextBox2_TextChanged(object sender, EventArgs e)
		{
			Func.Sendbytemess = new Entry.ByteMessage() { Data = richTextBox2.Text.ToBitArray(), IsSend = true, Time = DateTime.Now }; ;

		}
	}
}
