﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UpperComAutoTest.Entry;
using UpperComAutoTest.Entry.IEventFileModel.IMsgEvent;

namespace UpperComAutoTest.SendorEvent
{

    internal class CurrentPortSendMessageEvent
	{
        public ByteMessage Msg { get; set; }
    }
}
