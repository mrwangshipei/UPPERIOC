using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UPPERIOC.UPPER.IOC.Extend;
using UPPERIOC2.UPPER.UFileModel.Model;
using UPPERIOC2.UPPER.UFileModel.Center;
using UPPERIOC.UPPER.IOC.Annaiation;

namespace UPPERIOC.UPPER.DefaultProvider.Builder
{
  
    public class InstanceBuilder
    {
        private readonly ConcurrentDictionary<Type, ConstructorInfo> _constructorCache = new();
        private readonly ConcurrentDictionary<Type, PropertyInfo[]> _propertyCache = new();
        private readonly Func<Type, object> _resolveFunc;
        private readonly Func<Type, bool, string, object> _resolveWithParams;

        public InstanceBuilder(Func<Type, object> resolveFunc, Func<Type, bool, string, object> resolveWithParams)
        {
            _resolveFunc = resolveFunc;
            _resolveWithParams = resolveWithParams;
        }

        public object CreateInstance(Type type, bool subRegister = false, string name = null)
        {
            if (type == null) return null;

            // Check if type is allowed to be instantiated
            if (!type.HasBaseClassWithAttribute<IOCObject>() && subRegister)
            {
                return null;
            }

            var constructor = GetConstructor(type);
            var parameters = constructor.GetParameters();
            var paramValues = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var paramType = parameters[i].ParameterType;
                var paramName = name;
                object dependency = _resolveWithParams(paramType, true, paramName);

                if (dependency == null)
                {
                    dependency = CreateInstance(paramType, true, paramName);
                }

                paramValues[i] = dependency;
            }

            object instance = constructor.Invoke(paramValues);

            // Special handling for IModel
            if (typeof(IModel).IsAssignableFrom(type) && instance is IModel model)
            {
                instance = F.I.GetModel(model);
            }

            InjectProperties(instance, name);

            return instance;
        }

        private ConstructorInfo GetConstructor(Type type)
        {
            return _constructorCache.GetOrAdd(type, t =>
            {
                var ctors = t.GetConstructors();
                var selected = ctors.FirstOrDefault(c => c.GetCustomAttribute<IOCConstructor>() != null);
                return selected ?? ctors.FirstOrDefault() ?? throw new Exception($"请至少为{t.Name}类保留一个开放的构造函数");
            });
        }

        private void InjectProperties(object instance, string name)
        {
            var props = _propertyCache.GetOrAdd(instance.GetType(), t =>
                t.GetProperties().Where(p => p.GetCustomAttribute<IOCPorpeties>() != null).ToArray());

            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<IOCPorpeties>();
                var propInstance = _resolveWithParams(prop.PropertyType, false, attr?.Name ?? name);
                prop.SetValue(instance, propInstance);
            }
        }
    }

}
