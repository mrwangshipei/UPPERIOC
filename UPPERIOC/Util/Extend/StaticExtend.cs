using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UPPERIOC.UPPER.IOC.MyTypeInfo;

namespace UPPERIOC.UPPER.IOC.Extend
{
    public static class StaticExtend
    {
        // 判断是否有指定特性存在于基类上
        public static bool HasBaseClassWithAttribute<TAttribute>(this Type type) where TAttribute : Attribute
        {
            while (type != null && type != typeof(object))
            {
                if (type.GetCustomAttribute<TAttribute>() != null)
                    return true;

                type = type.BaseType;
            }
            return false;
        }

        // 判断是否是单例（根据名称）
        public static bool? IsSingleBean(this ConcurrentDictionary<IOCTypeInfo, object> dict, string typeName)
        {
            var entry = dict.FirstOrDefault(x => x.Key.TypeName == typeName);
            return entry.Key?.SingleBean;
        }

        // 判断是否是单例（根据类型）
        public static bool? IsSingleBean(this ConcurrentDictionary<IOCTypeInfo, object> dict, Type type)
        {
            var entry = dict.FirstOrDefault(item => item.Key.Type.IsCompatibleWith(type));
            return entry.Key?.SingleBean;
        }

        // 查找第一个满足条件的键值对
        public static KeyValuePair<IOCTypeInfo, object>? Find(this ConcurrentDictionary<IOCTypeInfo, object> dict, Func<KeyValuePair<IOCTypeInfo, object>, bool> predicate)
        {
            foreach (var item in dict)
            {
                if (predicate(item))
                    return item;
            }
            return null;
        }

        // 获取所有符合类型的实例
        public static object[] GetAllInstances(this ConcurrentDictionary<IOCTypeInfo, object> dict, Type type)
        {
            return dict
                .Where(item => item.Key.Type.IsCompatibleWith(type))
                .Select(item => item.Value)
                .ToArray();
        }

        // 获取实例（通过类型或名称）
        public static object GetInstance(this ConcurrentDictionary<IOCTypeInfo, object> dict, Type type = null, string name = null, bool includeSub = false)
        {
            if (type != null)
            {
                return includeSub
                    ? dict.FirstOrDefault(item => item.Key.Type.IsCompatibleWith(type)).Value
                    : dict.FirstOrDefault(item => item.Key.Type == type).Value;
            }

            if (!string.IsNullOrEmpty(name))
            {
                return dict.FirstOrDefault(item => item.Key.TypeName == name).Value;
            }

            return null;
        }

        // 类型兼容性判断（支持泛型判断）
        public static bool IsCompatibleWith(this Type actual, Type target)
        {
            if (actual == null || target == null)
                return false;

            if (actual == target)
                return true;

            if (actual.IsGenericType && target.IsGenericType)
            {
                if (actual.GetGenericTypeDefinition() != target.GetGenericTypeDefinition())
                    return false;

                var actualArgs = actual.GetGenericArguments();
                var targetArgs = target.GetGenericArguments();
                if (actualArgs.Length != targetArgs.Length)
                    return false;

                for (int i = 0; i < actualArgs.Length; i++)
                {
                    if (actualArgs[i] != targetArgs[i])
                        return false;
                }

                return true;
            }

            return target.IsAssignableFrom(actual);
        }

        // 判断一个类型是否处于另一个类型的继承链中
        public static bool IsInBaseTypeHierarchy(this Type type, Type baseType)
        {
            if (baseType == null || (!baseType.IsClass && !baseType.IsInterface))
                return false;

            if (type == baseType)
                return true;

            var current = type.BaseType;
            while (current != null)
            {
                if (current == baseType)
                    return true;
                current = current.BaseType;
            }

            return baseType.IsInterface && type.GetInterfaces().Contains(baseType);
        }

        // 自定义 FirstOrDefault 带默认值
        public static KeyValuePair<T, V> FirstOrDefaultOr<T, V>(this IEnumerable<KeyValuePair<T, V>> source, Func<KeyValuePair<T, V>, bool> predicate, KeyValuePair<T, V> defaultValue)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    return item;
            }
            return defaultValue;
        }
    }
}
