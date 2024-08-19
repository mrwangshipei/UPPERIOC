using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace UPPERIOC2.UPPER.Util
{
	public class RigisterObjLoad
	{
		public static RigisterObjLoad GetInstance(string root) {
			RigisterObjLoad r = new RigisterObjLoad();
			r.RegistryRoot = root;
			return r;
		}
		private  string RegistryRoot ;

		public  void SaveObjectToRegistry(string keyName, object obj)
		{
			if (obj == null)
			{
				return;
			}
			XmlSerializer xml = new XmlSerializer(obj.GetType());
			StringWriter sw = new StringWriter();
			xml.Serialize(sw,obj);
			Registry.SetValue(RegistryRoot,keyName, sw.ToString());
		}

		public  T LoadObjectFromRegistry<T>(string keyName) where T : new()
		{
			XmlSerializer xml = new XmlSerializer(typeof(T));
			string t = (string)Registry.GetValue(RegistryRoot,keyName, null) ;
			if (t == null)
			{
				return default(T);
			}
			StringReader sw = new StringReader(t);
			return (T)xml.Deserialize(sw);

		}
	}
}
