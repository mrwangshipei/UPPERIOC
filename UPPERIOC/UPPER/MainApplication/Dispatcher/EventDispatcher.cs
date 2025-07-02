using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.Event.AppEvent;
using UPPERIOC.UPPER.IOC.Center.IProvider;

namespace UPPERIOC.UPPER.MainApplication.Dispatcher
{
    public static class EventDispatcher
    {
        public static ApplicationEventManager InitAndRegister(IContainerProvider container)
        {
            var manager = container.GetInstance<ApplicationEventManager>();

            var mainAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(a => a.GetTypes().Any(t => t.Name == "IOCGeneratedRegistration"));

            var type = mainAssembly?.GetType("UPPER.Generated.IOCGeneratedRegistration");
            var method = type?.GetMethod("RegisterListener", BindingFlags.Public | BindingFlags.Static);

            method?.Invoke(null, new object[] { manager });

            return manager;
        }
    }

}
