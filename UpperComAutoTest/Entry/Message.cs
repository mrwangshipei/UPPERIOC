﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpperComAutoTest.Entry
{
	public class ByteMessage
	{
		public bool IsSend { get; set; }
		public byte[] Data{ get; set; }
		public Exception Err{ get; set; }
		public DateTime Time{ get; set; }

    }
}
