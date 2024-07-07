using FCT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UpperComAutoTest.Entry;

namespace UpperComAutoTest.Entry.IEventFileModel.IMsgEvent
{
    [Serializable]
    public abstract class MsgEventInterface
    {

        internal ByteMessage Sendbytemess { get; set; }

        internal ByteMessage Receivebytemess { get; set; }

    }
}
