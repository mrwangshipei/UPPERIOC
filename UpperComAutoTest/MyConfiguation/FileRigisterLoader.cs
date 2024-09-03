using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC2.UPPER.Premission;

namespace Common.MConfigration
{
	[IOCObject]
	public class RigisterObjLoadToFile : RigisterObjLoad
	{
		public override void SaveObjectToRegistry(string keyName, object obj)
		{
			XmlSerializer xml = new XmlSerializer(obj.GetType());
			StringWriter sw = new StringWriter();
			xml.Serialize(sw, obj);
			File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lock.txt"), sw.ToString());
		}

		public override T LoadObjectFromRegistry<T>(string keyName)
		{
			XmlSerializer xml = new XmlSerializer(typeof(T));
			string t = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lock.txt"));
			if (t == null)
			{
				return default;
			}
			StringReader sw = new StringReader(t);
			return (T)xml.Deserialize(sw);

		}
	}
}
