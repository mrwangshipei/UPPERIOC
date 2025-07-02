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
using UPPERIOC.UPPER.DefaultProvider.Builder;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.IOC.Extend;
using UPPERIOC.UPPER.IOC.MyTypeInfo;
using UPPERIOC2.UPPER.UFileModel.Center;
using UPPERIOC2.UPPER.UFileModel.Model;

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
            /* if (!item.HasBaseClassWithAttribute<IOCObject>() && SubRegister)
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
                throw new Exception($"请至少为{item.Name}类保留一个开放的构造函数");
             }
             var par = new object[cos.GetParameters().Length];
             for (int i = 0; i < cos.GetParameters().Length; i++)
             {
                 try
                 {

                     //容器不存在实例，注册，存在则取出
                     if ((par[i] = Contain.GetInstance(cos.GetParameters()[i].ParameterType, name, true)) == null)
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
             object obj = null;
             if (HasIModelAncestor(item))
             {
                 if ((obj = cos.Invoke(par))is IModel il)
                 {
                     obj = F.I.GetModel(il);
                 }
             }
             else
             {
                obj = cos.Invoke(par);

             }
             foreach (var prop in item.GetProperties().Where(p => p.GetCustomAttribute<IOCPorpeties>() != null))
             {
                 var attr = prop.GetCustomAttribute<IOCPorpeties>();
                 var propValue = InitInstance(prop.PropertyType, false, attr?.Name);
                 prop.SetValue(obj, propValue);
             }

             //item.GetProperties().Where(item1 => item1.GetCustomAttribute<IOCPorpeties>() != null).All(item1 => { item1.SetValue(obj, InitInstance(item1.PropertyType, false, item1.GetCustomAttribute<IOCPorpeties>()?.Name)); return true; });
             return obj;*/
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
                return default(T);
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
                return default(T);
            }
            return (T)(Contain[new IOCTypeInfo() { Type = typeof(T), TypeName = typeof(T).Name , SingleBean = SingleBean }] = InitInstance(typeof(T)));
        }


        public T Rigister<T>(string name, bool SingleBean = true)
        {
            if (Contain.GetInstance(name:name) != null)
            {
                return default(T);
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
