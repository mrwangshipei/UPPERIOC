
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace COMIEEE.Util
{
	public class Deepcopy
	{
		public static T DeepCopy<T>(T obj)
		{
			using (var ms = new MemoryStream())
			{
				IFormatter formatter = new BinaryFormatter();
				formatter.Serialize(ms, obj);
				ms.Seek(0, SeekOrigin.Begin);
				return (T)formatter.Deserialize(ms);
			}
		}
	}
}
