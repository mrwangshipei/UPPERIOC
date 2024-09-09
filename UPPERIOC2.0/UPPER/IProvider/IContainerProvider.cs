using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Annaiation;

namespace UPPERIOC.UPPER.IOC.Center.IProvider
{
	public interface IContainerProvider
	{
			 object GetInstance(Type type);
			 T GetInstance<T>();
			 T GetInstance<T>(string name);
		 object[] GetAllInstance(Type type);
		 T[] GetAllInstance<T>( );
		 object GetInstance(string name);

		 object GetInstance(Type type, string name);

		 T Rigister<T>();
		 object Rigister(Type T);

		object Rigister(Type T,object obj);
		object Rigister(Type T, string name);
		object Rigister(Type T,string name,object obj);
		object Rigister<T>(object obj);

		T Rigister<T>(string name);
	}
}
