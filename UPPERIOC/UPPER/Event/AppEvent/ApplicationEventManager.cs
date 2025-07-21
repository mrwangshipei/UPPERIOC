using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.Event.AppEvent.Impl;//这个命名空间改了，记得改掉代码里的
using UPPERIOC.UPPER.Event.Attri;

namespace UPPERIOC.UPPER.Event.AppEvent
{
    public class ApplicationEventManager
    {
        private readonly Dictionary<Type, Dictionary<int, List<object>>> _listeners = new();

        // 注册监听器
        public void RegisterListener<T>(IUPPERApplicationListener<T> listener) where T : IUPPERApplicationEvent, new()
        {
            var eventType = listener.GetType();
          
            
            int ord = GetOrder(listener.GetType());
            Type[] findstype = eventType.GetInterfaces();
            Type[] ctypes = null;
            if ((ctypes = findstype.ToList().FindAll(x => x.FullName.Contains("UPPERIOC.UPPER.Event.AppEvent.Impl.IUPPERApplicationListener")).ToArray()).Length > 0)  // 先确认是不是泛型类型
            {
                try
                {
                    // 获取泛型参数
                    ctypes = ctypes.Select(x => x.GetGenericArguments()[0]).ToArray() ;

                    // 你可以在这里继续使用 genericArgument 来进行后续处理
                }
                catch (Exception ex)
                {
                    throw new Exception("确保事件IUPPERApplicationListener类型正确，并且注册了事件参数", ex);
                }
            }
            else
            {
                throw new Exception("确保事件IUPPERApplicationListener类型正确，并且注册了事件参数,");
            }

            if (ord < 0)
            {
                throw new Exception("[Order]在此处大于等于0");
            }
            foreach (var ctype in ctypes)
            {
                
                if (!_listeners.ContainsKey(ctype))
                {
                    _listeners[ctype] = new Dictionary<int, List<object>>();
                }
                if (!_listeners[ctype].ContainsKey(ord))
                {
                    _listeners[ctype][ord] = new List<object>();
                    _listeners[ctype][ord].Add(listener);
                }
                else
                {
                    _listeners[ctype][ord].Add(listener);
                }
            }

        }
        public void RegisterListener(Type eventType)
        {
            
            int ord = GetOrder(eventType);
            if (ord < 0)
            {
                throw new Exception("[Order]在此处大于等于0");
            }
            Type[] findstype = eventType.GetInterfaces();
            Type[] ctypes = null;
            if ((ctypes = findstype.ToList().FindAll(x => x.FullName.Contains("UPPERIOC.UPPER.Event.AppEvent.Impl.IUPPERApplicationListener")).ToArray()).Length > 0)  // 先确认是不是泛型类型
            {
                try
                {
                    // 获取泛型参数
                    ctypes = ctypes.Select(x => x.GetGenericArguments()[0]).ToArray();

                    // 你可以在这里继续使用 genericArgument 来进行后续处理
                }
                catch (Exception ex)
                {
                    throw new Exception("确保事件IUPPERApplicationListener类型正确，并且注册了事件参数", ex);
                }
            }
            else
            {
                throw new Exception("确保事件IUPPERApplicationListener类型正确，并且注册了事件参数,");
            }

            if (ord < 0)
            {
                throw new Exception("[Order]在此处大于等于0");
            }
            foreach (var ctype in ctypes)
            {

                if (!_listeners.ContainsKey(ctype))
                {
                    _listeners[ctype] = new Dictionary<int, List<object>>();
                }
                var listener = Activator.CreateInstance(eventType);
                if (!_listeners[ctype].ContainsKey(ord))
                {
                    _listeners[ctype][ord] = new List<object>();
                    _listeners[ctype][ord].Add(listener);
                }
                else
                {
                    _listeners[ctype][ord].Add(listener);
                }
            }
         

        }
        public void PublishEvent<T>(T applicationEvent) where T : IUPPERApplicationEvent, new()
        {
            var lis = new List<IUPPERApplicationListener<T>>();
            var liwait = new List<IUPPERApplicationListener<T>>();
            var eventType = applicationEvent.GetType();

            if (_listeners.ContainsKey(eventType))
            {
                foreach (var listener in _listeners[eventType].OrderBy(x => x.Key))
                {
                    foreach (var item in listener.Value.OrderBy(x => GetOrder(x.GetType())))
                    {
                        if (item is IUPPERApplicationListener<T> li)
                        {
                            if (!string.IsNullOrWhiteSpace(GetAfter(li.GetType())))
                            {
                                liwait.Add(li);
                            }
                            else
                            {
                                lis.Add(li);
                            }
                        }
                    }
                }
            }

            foreach (var item in lis.OrderBy(x => GetOrder(x.GetType())))
            {
                var next = liwait.Find(x => GetAfter(x.GetType()) == item.MoudleName);
                if (next != null)
                {
                    Console.WriteLine($"Executing {item.MoudleName} before {next.MoudleName}");
                    item.OnEvent(applicationEvent);
                    next.OnEvent(applicationEvent);

                }
                else
                {
                    Console.WriteLine($"Executing {item.MoudleName}");
                    item.OnEvent(applicationEvent);

                }
            }
        }

        /// <summary>
        /// 获取类的 Order 特性值
        /// </summary>
        /// <param name="type">类的类型</param>
        /// <returns>Order 值（默认为 0）</returns>
        private int GetOrder(Type type)
        {
            var orderAttribute = type.GetCustomAttributes(typeof(OrderAttribute), false).FirstOrDefault() as OrderAttribute;
            return orderAttribute?.Order ?? 0;
        }

        /// <summary>
        /// 获取类的 After 特性值
        /// </summary>
        /// <param name="type">类的类型</param>
        /// <returns>After 值（默认为空字符串）</returns>
        private string GetAfter(Type type)
        {
            var afterAttribute = type.GetCustomAttributes(typeof(AfterAttribute), false).FirstOrDefault() as AfterAttribute;
            return afterAttribute?.After ?? string.Empty;
        }

    }

}
