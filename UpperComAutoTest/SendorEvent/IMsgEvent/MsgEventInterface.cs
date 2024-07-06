using FCT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UpperComAutoTest.Entry;

namespace UpperComAutoTest.SendorEvent.IMsgEvent
{
	[Serializable]
	public abstract class MsgEventInterface
	{
        public ByteMessage Sendbytemess { get; set; }
		[XmlIgnore]
        public ByteMessage Receivebytemess { get; set; }

    }
}
