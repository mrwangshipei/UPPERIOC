using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using UPPERIOC2.UPPER.UFileModel.Model;

namespace UPPERIOC2.UPPER.Translate.Model
{
	public class TranslateModel : IModel
	{
		public override string ModelName { get=>"translate"; set { } }
		[XmlElement]
		public List<Translateblock> Translateblocks { get; set; } = new List<Translateblock>();
		
	}
	
	public class Translateblock {
		[XmlElement]
		public string Name { get; set; }
		[XmlElement]
		public List<KeyValue> Values { get; set; } = new List<KeyValue>();

	}
	public struct KeyValue {
		[XmlElement]
		public string Key { get; set; }
        [XmlElement]
		public string Value { get; set; }

        public KeyValue(string text, string str) : this()
		{
			this.Key= text;
			this.Value= str;
		}
	}
}
