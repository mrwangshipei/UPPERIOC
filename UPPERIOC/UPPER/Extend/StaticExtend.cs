using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using UPPERIOC.UPPER.IOC.MyTypeInfo;

namespace UPPERIOC.UPPER.IOC.Extend
{
	public static class StaticExtend
	{
		public static bool HasBaseClassWithAttribute<TAttribute>(this Type type) where TAttribute : Attribute
		{
			while (type != null && type != typeof(object))
			{
				if (type.GetCustomAttribute<TAttribute>() != null)
				{
					return true;
				}
				type = type.BaseType; // 移动到继承链中的下一个基类  
			}
			return false;
		}
		public static object GetIntstance(this ConcurrentDictionary<IOCTypeInfo, object> kv, string name)
		{
			return kv.GetIntstance(null, name, false);
		}
		public static object GetIntstance(this ConcurrentDictionary<IOCTypeInfo, object> kv, Type t, bool containsub = false)
		{
			return kv.GetIntstance(t, null, containsub);

		}
		public static object[] GetAllInstance(this ConcurrentDictionary<IOCTypeInfo, object> kv, Type t)
		{
			return kv.Where(item => AreGenericParametersEqual(item.Key.Type,t) && (item.Key.Type.IsSubclassOf(t) || t.IsAssignableFrom(item.Key.Type))).Select(item => item.Value).ToArray();

		}
        public static bool AreGenericParametersEqual(Type type1, Type type2)
        {
            // 确保类型都是泛型类型
            if (type1.IsGenericType && type2.IsGenericType)
            {
                // 获取泛型定义是否一致
                if (type1.GetGenericTypeDefinition() == type2.GetGenericTypeDefinition())
                {
                    // 获取并比较泛型参数类型
                    Type[] typeArgs1 = type1.GetGenericArguments();
                    Type[] typeArgs2 = type2.GetGenericArguments();

                    // 比较泛型参数的数量和每个参数的类型
                    if (typeArgs1.Length == typeArgs2.Length)
                    {
                        for (int i = 0; i < typeArgs1.Length; i++)
                        {
                            if (typeArgs1[i] != typeArgs2[i]) // 类型参数不匹配
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                }
            }
            else
            {
                return true;

            }
                return false;
        }

        public static object GetIntstance(this ConcurrentDictionary<IOCTypeInfo, object> kv, Type t, string name,bool containsub = false)
        {
            if (t != null)
            {
                if (containsub)
                {
					return kv.Where(item => AreGenericParametersEqual(item.Key.Type, t) && (item.Key.Type.IsSubclassOf(t) || t.IsAssignableFrom(item.Key.Type))).FirstOrDefault(item => true).Value;
				}
                return kv?.FirstOrDefault(item => item.Key.Type == t, new KeyValuePair<IOCTypeInfo, object>(null,null)).Value;
            }
            else if (name != null)
            {
                return kv?.FirstOrDefault(item => item.Key.TypeName == name, new KeyValuePair<IOCTypeInfo, object>(null, null)).Value;

            }
            else
            {
                return kv?.FirstOrDefault(item => item.Key.TypeName == name && item.Key.Type == t, new KeyValuePair<IOCTypeInfo, object>(null,null)).Value;

            }
        }

		public static KeyValuePair<T, V> FirstOrDefault<T,V>(this ConcurrentDictionary<T, V> kv,Func<KeyValuePair<T,V>,bool> func, KeyValuePair<T, V> defaultv )
		{
			return (kv?.FirstOrDefault(func).Equals( default(KeyValuePair<T, V>)) == true) ? defaultv : kv.FirstOrDefault(func);
		}
	}
}
