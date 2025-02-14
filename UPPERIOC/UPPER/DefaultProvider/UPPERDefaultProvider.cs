using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.IOC.Extend;
using UPPERIOC.UPPER.IOC.MyTypeInfo;

namespace UPPERIOC2.UPPER.UIOC.DefaultProvider
{

    public class UPPERDefaultProvider : IContainerProvider
    {
        ConcurrentDictionary<IOCTypeInfo, object> Contain = new ConcurrentDictionary<IOCTypeInfo, object>();

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

        public object InitInstance(Type item = null, bool SubRegister = false, string name = null)
        {
            if (!item.HasBaseClassWithAttribute<IOCObject>() && SubRegister)
            {
                //throw new Exception($"对象{item.FullName}不被容器管理");
                return null;
            }
            ConstructorInfo cos = null;
            try
            {

                cos = item.GetConstructors().ToList().FirstOrDefault(item1 => item1.GetCustomAttribute(typeof(IOCConstructor)) != null) == null ? item.GetConstructors()[0] : item.GetConstructors().ToList().FirstOrDefault(item1 => item1.GetCustomAttribute(typeof(IOCConstructor)) != null);
            }
            catch (Exception)
            {
                return null;
               // throw new Exception($"获取{item.Name}的构造报错");
            }
            var par = new object[cos.GetParameters().Length];
            for (int i = 0; i < cos.GetParameters().Length; i++)
            {
                try
                {

                    //容器不存在实例，注册，存在则取出
                    if ((par[i] = Contain.GetIntstance(cos.GetParameters()[i].ParameterType, name, true)) == null)
                    {

                        par[i] = InitInstance(cos.GetParameters()[i].ParameterType, true);
                        //若注册了，则必须保存在容器中

                        // if (Contain.All(item => item.Key.Type != cos.GetParameters()[i].ParameterType))
                        {
                            Contain[new IOCTypeInfo() { Type = cos.GetParameters()[i].GetType(), TypeName = string.IsNullOrWhiteSpace(name) ? cos.GetParameters()[i].GetType().Name : name }] = par[i];
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;


                }

            }
            object obj = cos.Invoke(par);
            item.GetProperties().Where(item1 => item1.GetCustomAttribute<IOCPorpeties>() != null).All(item1 => { item1.SetValue(obj, InitInstance(item1.PropertyType, false, item1.GetCustomAttribute<IOCPorpeties>()?.Name)); return true; });
            return obj;
        }

        public object GetInstance(Type type)
        {
            if (type == null)
            {
                return null;
            }
            if (Contain.IsSingleBean(type) == false) { 
                return InitInstance(type);
            }

            return Contain.GetIntstance(type); ;
        }
        public object GetInstance(string names)
        {
            if (Contain.IsSingleBean(names) == false)
            {
                return InitInstance(name : names);
            }

            return Contain.GetIntstance(names);
        }

        public object[] GetAllInstance(Type type)
        {
            return Contain.GetAllInstance(type); ;
        }
        public T[] GetAllInstance<T>()
        {
            return Contain.GetAllInstance(typeof(T)).Select(t => (T)t).ToArray(); ;
        }
        public T GetInstanceAndSub<T>()
        {
            if (Contain.IsSingleBean(typeof(T)) == false)
            {
                return (T)InitInstance(item:typeof(T));
            }
            return (T)Contain.GetIntstance(typeof(T), true);
        }

        public T GetInstance<T>()
        {
            if (Contain.IsSingleBean(typeof(T)) == false)
            {
                return (T)InitInstance(item: typeof(T));
            }
            return (T)Contain.GetIntstance(typeof(T));
        }
        public T GetInstance<T>(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return default(T);
            }
            if (Contain.IsSingleBean(typeof(T)) == false)
            {
                return (T)InitInstance(item: typeof(T));
            }
            return (T)Contain.GetIntstance(typeof(T), name); ;
        }
        public object GetInstance(Type type, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }
            if (Contain.IsSingleBean(type) == false)
            {
                return InitInstance(item: type);
            }
            return Contain.GetIntstance(type, name); ;

        }
        public T Rigister<T>(bool SingleBean = true)
        {
            if (Contain.GetIntstance(typeof(T)) != null)
            {
                return default(T);
            }
            return (T)(Contain[new IOCTypeInfo() { Type = typeof(T), TypeName = typeof(T).Name , SingleBean = SingleBean }] = InitInstance(typeof(T)));
        }


        public T Rigister<T>(string name, bool SingleBean = true)
        {
            if (Contain.GetIntstance(name) != null)
            {
                return default(T);
            }
            return (T)(Contain[new IOCTypeInfo() { Type = typeof(T), TypeName = name, SingleBean = SingleBean }] = InitInstance(typeof(T)));

        }

        public object Rigister(Type T, bool SingleBean = true)
        {
            if (Contain.GetIntstance(T) != null)
            {
                return null; ;
            }
            return Contain[new IOCTypeInfo() { Type = T, TypeName = T.Name , SingleBean = SingleBean }] = InitInstance(T);
        }

     
        public object Rigister(Type T, object obj)
        {
            return Rigister(T, T.Name, obj);
        }

        public object Rigister<T>(object obj)
        {
            return Rigister(typeof(T), obj);
        }

        public object Rigister(Type T, string name, object obj)
        {
            return Contain[new IOCTypeInfo() { Type = T, TypeName = name }] = obj;
        }
		
        public object Rigister(Type T, string name, bool SingleBean = true)
		{
			return Contain[new IOCTypeInfo() { Type = T, TypeName = name, SingleBean = SingleBean }] = InitInstance(T);

		}

	
	}
}
