using System;
using System.Collections.Concurrent;
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
		public static object GetIntstance(this ConcurrentDictionary<UpperTypeInfo, object> kv, string name)
        {
            return kv.GetIntstance(null, name, false);
        }
		public static object GetIntstance(this ConcurrentDictionary<UpperTypeInfo, object> kv, Type t, bool containsub = false)
		{
			return kv.GetIntstance(t, null,containsub);

		}
        public static object[] GetAllInstance(this ConcurrentDictionary<UpperTypeInfo, object> kv, Type t)
        {
            return kv.Where(item => item.Key.Type.IsSubclassOf(t) || t.IsAssignableFrom(item.Key.Type)).Select(item => item.Value).ToArray();

		}
		public static object GetIntstance(this ConcurrentDictionary<UpperTypeInfo, object> kv, Type t, string name,bool containsub = false)
        {
            if (t != null)
            {
                if (containsub)
                {
                    return kv.Where(item => item.Key.Type.IsSubclassOf(t) || t.IsAssignableFrom(item.Key.Type)).FirstOrDefault(item => true, default(KeyValuePair<UpperTypeInfo, object>)).Value;
				}
                return kv?.FirstOrDefault(item => item.Key.Type == t, new KeyValuePair<UpperTypeInfo, object>(null,null)).Value;
            }
            else if (name != null)
            {
                return kv?.FirstOrDefault(item => item.Key.TypeName == name, new KeyValuePair<UpperTypeInfo, object>(null, null)).Value;

            }
            else
            {
                return kv?.FirstOrDefault(item => item.Key.TypeName == name && item.Key.Type == t, new KeyValuePair<UpperTypeInfo, object>(null,null)).Value;

            }
        }
    }
}
