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
using UpperComAutoTest.MyControls.FuncControl.TypeEdit.IFactory;

namespace UpperComAutoTest.MyControls.FuncControl.TypeEdit
{
	public partial class NormalFuncControl : IFuncTypeEdit
	{
		public override MsgEventInterface msg { get => base.msg; set => base.msg = value; }

		private NormalFuncEvent Func { get => msg as NormalFuncEvent; set => msg = value; }
		public NormalFuncControl()
		{
			InitializeComponent();
			Func = new NormalFuncEvent();
		}
		public NormalFuncControl(NormalFuncEvent Func)
		{
			InitializeComponent();
			this.Func = Func;
			richTextBox1.Text = Func.Receivebytemess.Data.ByteArrayToHex(" ");
			richTextBox2.Text = Func.Sendbytemess.Data.ByteArrayToHex(" ");
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
	public class NormalFuncFactory : IFuncFactory
	{
		public string ProductName { get => "即回事件"; set => throw new NotImplementedException(); }
		public Type ProductType { get => typeof(NormalFuncEvent); set => throw new NotImplementedException(); }

		public IFuncTypeEdit CreateIFuncControl(MsgEventInterface msg)
		{
			return new NormalFuncControl(msg as NormalFuncEvent);
		}
		public IFuncTypeEdit CreateIFuncControl()
		{
			return new NormalFuncControl();
		}
	}
}
