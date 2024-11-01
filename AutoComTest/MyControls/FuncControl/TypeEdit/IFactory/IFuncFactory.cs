using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpperComAutoTest.Entry.IEventFileModel.IMsgEvent;

namespace UpperComAutoTest.MyControls.FuncControl.TypeEdit.IFactory
{
	public interface IFuncFactory
	{
         Type ProductType { get; set; }
         string ProductName { get; set; }
         IFuncTypeEdit CreateIFuncControl(MsgEventInterface msg);
         IFuncTypeEdit CreateIFuncControl();
	}
}
