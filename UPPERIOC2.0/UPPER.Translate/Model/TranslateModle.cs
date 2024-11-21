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
		public List<Translateblock> Translateblocks = new List<Translateblock>();
		
	}
	
	public class Translateblock {
		[XmlElement]
		public string Name;
		[XmlElement]
		public List<KeyValue> Values = new List<KeyValue>();

	}
	public struct KeyValue {
		[XmlElement]
		public string Key;
		[XmlElement]
		public string Value;

		public KeyValue(string text, string str) : this()
		{
			this.Key= text;
			this.Value= str;
		}
	}
}
