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
		public string Name { get; internal set; }
        public ByteMessage Sendbytemess { get; set; } = new ByteMessage();

        public ByteMessage Receivebytemess { get; set; } = new ByteMessage();

    }
}
