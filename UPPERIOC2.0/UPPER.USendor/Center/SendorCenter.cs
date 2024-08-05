using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Center.IProvider;

namespace UPPERIOC2.UPPER.USendor.Center
{
    public class SendorCenter
    {
        public static IContainerProvider Contain;
        static ConcurrentDictionary<Type, Func<object, object>> Events = new ConcurrentDictionary<Type, Func<object, object>>();
        public static void Register<TEvent>(Action<TEvent> @event)
        {
            Events[typeof(TEvent)] = new Func<object, object>((obj) =>
            {
                @event?.Invoke((TEvent)obj);
                return null;
            });

        }

        public static void Register<TInEvent>(Func<TInEvent, object> @event)
        {
            Events[typeof(TInEvent)] = new Func<object, object>((obj) =>
            {
                return @event?.Invoke((TInEvent)obj);
            });

        }

        public static object Publish<TEvent>(TEvent T)
        {
            return Events[typeof(TEvent)]?.Invoke(T);


        }

    }
}
