using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UpperComAutoTest.SendorEvent.IMsgEvent;
using UPPERIOC2._0.UPPER.UFileModel.IModel;

namespace UpperComAutoTest.SendorEvent.IEventFileModel
{
	internal class EventFileModel :IModel
	{
		[XmlIgnore]
		public override string ModelName { get => "EventModel.xml"; set { } }
        public List<MsgEventInterface> Msgevens{ get; set; }

    }
}
