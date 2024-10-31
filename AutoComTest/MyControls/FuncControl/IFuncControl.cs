using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpperComAutoTest.Entry;

namespace UpperComAutoTest.MyControls.FuncControl
{
    internal interface IFuncControl
    {
         ByteMessage Receive { get; set; }
         ByteMessage Send { get; set; }
    }
}
