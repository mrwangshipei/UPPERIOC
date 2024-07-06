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
<<<<<<< HEAD

			 object GetInstance(Type type);
=======
		 object GetInstance(Type type);
>>>>>>> 39897f155fb182076b4399bde322300430fb78cd
		 object[] GetAllInstance(Type type);
		 object GetInstance(string name);

		 object GetInstance(Type type, string name);

		 T Rigister<T>();
		 object Rigister(Type T);

		object Rigister(Type T,object obj);
		object Rigister(Type T,string name,object obj);
		object Rigister<T>(object obj);

		T Rigister<T>(string name);
	}
}
