﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UpperComAutoTest.Entry.IEventFileModel.IMsgEvent;
using UPPERIOC2.UPPER.UFileModel.IModel;

namespace UpperComAutoTest.Entry.IEventFileModel
{
    public class EventFileModel : IModel
    {
        [XmlIgnore]
        public override string ModelName { get => "EventModel.xml"; set { } }
        public List<MsgEventInterface> Msgevens { get; set; } = new List<MsgEventInterface>();

    }
}
