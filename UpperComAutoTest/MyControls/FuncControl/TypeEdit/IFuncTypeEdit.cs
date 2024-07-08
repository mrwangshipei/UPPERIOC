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
	public  partial class IFuncTypeEdit : UserControl
	{
		public virtual MsgEventInterface msg { get; set; }

		public IFuncTypeEdit()
		{
			InitializeComponent();
		}
	}
}
