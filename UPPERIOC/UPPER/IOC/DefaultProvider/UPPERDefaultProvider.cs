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
using UPPERIOC.UPPER.IOC.DefaultProvider.Builder;
using UPPERIOC.UPPER.IOC.Extend;
using UPPERIOC.UPPER.IOC.MyTypeInfo;
using UPPERIOC2.UPPER.UFileModel.Center;
using UPPERIOC2.UPPER.UFileModel.Model;

namespace UPPERIOC.UPPER.IOC.DefaultProvider
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
        private readonly InstanceBuilder _builder;
        public UPPERDefaultProvider()
        {
            _builder = new InstanceBuilder(
                resolveFunc: (type) => Contain.GetInstance(type),
                resolveWithParams: (type, subReg, name) => GetOrCreateInstance(type, subReg, name)
            );
        }
        private object GetOrCreateInstance(Type type, bool subRegister, string name)
        {
            var existing = Contain.GetInstance(type, name, subRegister);
            if (existing != null) return existing;

            var instance = _builder.CreateInstance(type, subRegister, name);

            var key = new IOCTypeInfo
            {
                Type = type,
                TypeName = string.IsNullOrWhiteSpace(name) ? type.Name : name,
                SingleBean = true
            };

            Contain[key] = instance;
            return instance;
        }

        public object InitInstance(Type item = null, bool subRegister = false, string name = null)
        {
            return _builder.CreateInstance(item, subRegister, name);
        }
        public static bool HasIModelAncestor(Type itemType)
        {
            while (itemType != null)
            {
                // 检查是否是 IModel 类型或其子类
                if (typeof(IModel).IsAssignableFrom(itemType))
                {
                    return true;
                }
                // 获取当前类型的基类
                itemType = itemType.BaseType;
            }
            return false;
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

            return Contain.GetInstance(type); ;
        }
        public object GetInstance(string names)
        {
            if (Contain.IsSingleBean(names) == false)
            {
                return InitInstance(name : names);
            }

            return Contain.GetInstance(name:names);
        }

        public object[] GetAllInstance(Type type)
        {
            return Contain.GetAllInstances(type); ;
        }
        public T[] GetAllInstance<T>()
        {
            return Contain.GetAllInstances(typeof(T)).Select(t => (T)t).ToArray(); ;
        }
        public T GetInstanceAndSub<T>()
        {
            if (Contain.IsSingleBean(typeof(T)) == false)
            {
                Type real ;
                if ((real = Contain.Find(x => x.Key.Type.IsInBaseTypeHierarchy(typeof(T)))?.Key?.Type) == null)
                {
                    real = typeof(T);
                }
                return (T)InitInstance(item: real);
            }
            return (T)Contain.GetInstance(typeof(T), includeSub:true);
        }

        public T GetInstance<T>()
        {
            if (Contain.IsSingleBean(typeof(T)) == false)
            {
                return (T)InitInstance(item: typeof(T));
            }
            return (T)Contain.GetInstance(typeof(T));
        }
        public T GetInstance<T>(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return default;
            }
            if (Contain.IsSingleBean(typeof(T)) == false)
            {
                return (T)InitInstance(item: typeof(T));
            }
            return (T)Contain.GetInstance(typeof(T), name); ;
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
            return Contain.GetInstance(type, name); ;

        }
        public T Rigister<T>(bool SingleBean = true)
        {
            if (Contain.GetInstance(typeof(T)) != null)
            {
                return default;
            }
            return (T)(Contain[new IOCTypeInfo() { Type = typeof(T), TypeName = typeof(T).Name , SingleBean = SingleBean }] = InitInstance(typeof(T)));
        }


        public T Rigister<T>(string name, bool SingleBean = true)
        {
            if (Contain.GetInstance(name:name) != null)
            {
                return default;
            }
            return (T)(Contain[new IOCTypeInfo() { Type = typeof(T), TypeName = name, SingleBean = SingleBean }] = InitInstance(typeof(T)));

        }

        public object Rigister(Type T, bool SingleBean = true)
        {
            if (Contain.GetInstance(T) != null)
            {
                return null; ;
            }
            return Contain[new IOCTypeInfo() { Type = T, TypeName = T.Name , SingleBean = SingleBean }] = InitInstance(T);
        }

     
        public object Rigister(Type T, object obj)
        {
            return Rigister(T, T.Name, obj);
        }

     
        public F Rigister<F>(F obj)
        {
            return (F)Rigister(typeof(F), obj);
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
