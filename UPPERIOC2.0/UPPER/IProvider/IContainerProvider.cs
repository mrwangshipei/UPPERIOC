using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UPPERIOC.UPPER.IOC.Center.IProvider
{
	public interface IContainerProvider
	{

		 object GetInstance(Type type);
		 object[] GetAllInstance(Type type);
		 object GetInstance(string name);

		 object GetInstance(Type type, string name);

		 T Rigister<T>();
		 object Rigister(Type T);

		 T Rigister<T>(string name);
	}
}
