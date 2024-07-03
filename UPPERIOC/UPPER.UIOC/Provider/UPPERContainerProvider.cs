using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.IOC.Extend;
using UPPERIOC.UPPER.IOC.MyTypeInfo;

namespace UPPERIOC.UPPER.IOC.Provider
{

	public class UPPerContainerProvider : IContainerProvider
    {
        ConcurrentDictionary<UpperTypeInfo, object> Contain = new ConcurrentDictionary<UpperTypeInfo, object>();
        
     /*   private void GetInstance()
        {
            var list = Contain.Keys.ToList();
            foreach (var item in list)
            {
                if (Contain[item] == null)
                {
                    Contain[item] = InitInstance(item.Type);
                }

            }
        }*/

        public object InitInstance(Type item,bool SubRegister = false,string name = null)
        {
            if ((!item.HasBaseClassWithAttribute<IOCObject>() )&& SubRegister)
			{
                throw new Exception($"对象{item.FullName}不被容器管理");

			}
			ConstructorInfo cos = null;
            try
            {

                cos = item.GetConstructors().FirstOrDefault(item => item.GetCustomAttribute(typeof(IOCConstructor)) != null, item.GetConstructors()[0]);
            }
            catch (Exception)
            {

                throw new Exception($"获取{item.Name}的构造报错");
            }
            var par = new object[cos.GetParameters().Length];
            for (int i = 0; i < cos.GetParameters().Length; i++)
            {
                try
                {
                    
                    //容器不存在实例，注册，存在则取出
                    if ((par[i] = Contain.GetIntstance(cos.GetParameters()[i].ParameterType,name,true))== null)
                    {

                        par[i] = InitInstance(cos.GetParameters()[i].ParameterType,true);
					    //若注册了，则必须保存在容器中

					   // if (Contain.All(item => item.Key.Type != cos.GetParameters()[i].ParameterType))
                        {
                            Contain[new UpperTypeInfo() { Type = cos.GetParameters()[i].GetType(), TypeName =string.IsNullOrWhiteSpace(name)?cos.GetParameters()[i].GetType().Name :name}] = par[i];
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                    
                   
                }

            }
            object obj = cos.Invoke(par);
            item.GetProperties().Where(item => item.GetCustomAttribute<IOCPorpeties>() != null).All(item=> { item.SetValue(obj, InitInstance(item.PropertyType,false, item.GetCustomAttribute<IOCPorpeties>()?.Name));return true; }) ;
            return obj;
        }

        public object GetInstance(Type type)
        {
            if (type == null)
            {
                return null;
            }


            return Contain.GetIntstance(type); ;
        }

        public object GetInstance(Type type, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }
            return Contain.GetIntstance(type, name); ;

        }
        public T Rigister<T>()
        {
			if (Contain.GetIntstance(typeof(T)) != null)
			{
				return default(T);
			}
			return (T)(Contain[new UpperTypeInfo() { Type = typeof(T), TypeName = typeof(T).Name }] = InitInstance(typeof(T)));
        }


        public T Rigister<T>(string name)
        {
			if (Contain.GetIntstance(name) != null)
			{
				return default(T) ;
			}
			return (T)(Contain[new UpperTypeInfo() { Type = typeof(T), TypeName = name }] = InitInstance(typeof(T)));

        }

		public object Rigister(Type T)
		{
            if (Contain.GetIntstance(T) != null)
            {
                return null;  ;
            }
			return (Contain[new UpperTypeInfo() { Type = T, TypeName = T.Name }] = InitInstance(T));
		}

		public object GetInstance(string name)
		{

            return Contain.GetIntstance(name);
		}

		public object[] GetAllInstance(Type type)
		{
            return Contain.GetAllInstance(type); ;
		}
	}
}
