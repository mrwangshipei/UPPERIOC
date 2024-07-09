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
        public Type ProductType { get; set; }
        public string ProductName { get; set; }
        public IFuncTypeEdit CreateIFuncControl(MsgEventInterface msg);
        public IFuncTypeEdit CreateIFuncControl();
	}
}
