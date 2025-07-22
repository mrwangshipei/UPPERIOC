using System.Diagnostics;
using System.Windows.Forms;
using UPPERIOC.UPPER.Event.AppEvent;
using UPPERIOC.UPPER.Event.AppEvent.Impl;
using UPPERIOC.UPPER.IOC.Center.Configuation;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.MainApplication.Dispatcher;
using UPPERIOC.UPPER.MainApplication.Log_;
using UPPERIOC.UPPER.Moudle_;
using UPPERIOC.UPPER.Moudle_.Initializer;
using UPPERIOC2.UPPER.Model;
using UPPERIOC2.UPPER.UIOC.Center;

namespace UPPERIOC
{
    public class UPPERIOCApplication
    {
        public static IContainerProvider Container { get; set; }
        public static ApplicationEventManager EventManager { get; set; }
        public static VersionModel vm;
        internal static List<ILog> Log;
        
        public static void RunInstance(ModuleConfiguaion config)
        {
            LogManager.Init(config.Logs);
            Container = config.Provider;
            EventManager = EventDispatcher.InitAndRegister(Container);
      
            EventManager.PublishEvent(new ApplicationPreInitializationEvent());

            ModuleInitializer.InitModules(config);
            AppDomain.CurrentDomain.ProcessExit += (_, __) =>
            {
                EventManager.PublishEvent(new ApplicationStoppingEvent());
                config.UnLoadModules.ForEach(module => {
                    if (module is IModulePreDestruction pred)
                    {
                        pred.OnPreDestroy(Container);
                    }
                });
                EventManager.PublishEvent(new ApplicationStoppedEvent());
            };
        }
        public static void RunInstance(Action<ModuleConfiguaion> configAction = null,Action<ApplicationEventManager> eventAction = null)
        {
            var config = new ModuleConfiguaion();
            configAction?.Invoke(config);
            config.Provider = config.Provider;
            U._e = config.EventManager;
            eventAction?.Invoke(config.EventManager);
            RunInstance(config);
        }

        public static void RegisterVersionModel(VersionModel model)
        {
            if (model == null) return;
            vm = model;
        }
    }

}
