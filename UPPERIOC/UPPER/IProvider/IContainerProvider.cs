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
		T GetInstanceAndSub<T>();

		object GetInstance(Type type);
		T GetInstance<T>();
		T GetInstance<T>(string name);
		 object[] GetAllInstance(Type type);
		 T[] GetAllInstance<T>( );
		 object GetInstance(string name);

		 object GetInstance(Type type, string name);

		 T Rigister<T>(bool Single = true);
		 T Rigister<T>(T obj);
		 object Rigister(Type T, bool Single = true);
		T Rigister<T>(string name, bool Single = true);
		object Rigister(Type T, string name, bool Single = true);

		object Rigister(Type T,object obj);
		object Rigister(Type T,string name,object obj);

	}
}
