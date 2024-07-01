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

		public object GetInstance(Type type);
		public object[] GetAllInstance(Type type);
		public object GetInstance(string name);

		public object GetInstance(Type type, string name);

		public T Rigister<T>();
		public object Rigister(Type T);

		public T Rigister<T>(string name);
	}
}
