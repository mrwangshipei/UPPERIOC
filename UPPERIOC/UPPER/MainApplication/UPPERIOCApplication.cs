using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using UPPERIOC.UPPER;
using UPPERIOC.UPPER.Event.AppEvent;
using UPPERIOC.UPPER.Event.AppEvent.Impl;
using UPPERIOC.UPPER.IOC.Center.Configuation;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.IOC.Extend;
using UPPERIOC.UPPER.IOC.Moudle;
using UPPERIOC.UPPER.MainApplication.Dispatcher;
using UPPERIOC.UPPER.MainApplication.Initer;
using UPPERIOC.UPPER.MainApplication.Log_;
using UPPERIOC2.UPPER.Model;

namespace UPPERIOC
{
    public class UPPERIOCApplication
    {
        public static IContainerProvider Container { get; set; }
        public static ApplicationEventManager EventManager { get; set; }
        public static VersionModel vm;
        internal static List<ILog> Log;

        public static void RunInstance(MoudleConfiguaion config)
        {
            LogManager.Init(config.Logs);
            Container = config.Provider;
            EventManager = EventDispatcher.InitAndRegister(Container);

            EventManager.PublishEvent(new ApplicationStartingEvent());

            ModuleInitializer.InitModules(config);

            AppDomain.CurrentDomain.ProcessExit += (_, __) =>
            {
                EventManager.PublishEvent(new ApplicationStoppingEvent());
                EventManager.PublishEvent(new ApplicationStoppedEvent());
            };
        }

        public static void RegisterVersionModel(VersionModel model)
        {
            if (model == null) return;
            vm = model;
        }
    }

}
