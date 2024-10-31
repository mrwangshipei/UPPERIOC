using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UpperComAutoTest.Entry
{
	public class ByteMessage
	{
		public bool IsSend { get; set; }
		public byte[] Data { get; set; } = new byte[0];
		[XmlIgnore]
		public Exception Err{ get; set; }
		public DateTime Time{ get; set; }

    }
}
