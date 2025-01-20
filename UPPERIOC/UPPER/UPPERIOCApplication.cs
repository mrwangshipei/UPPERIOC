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
using UPPERIOC.UPPER.ILOG;
using UPPERIOC.UPPER.IOC.Center.Configuation;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.IOC.Extend;
using UPPERIOC.UPPER.IOC.Moudle;
using UPPERIOC2.UPPER.Model;

namespace UPPERIOC
{
    public class UPPERIOCApplication
    {
        public static IContainerProvider container;
       
        public static  VersionModel vm;
        internal static List<ILog> Log;
        /// <summary>
        /// 应用事件监听器
        ///  public class ApplicationStartingEvent : UPPERApplicationEvent { }
        ///public class ApplicationStartedEvent : UPPERApplicationEvent { }
        ///public class ApplicationPreCreatInstaceEvent : UPPERApplicationEvent { }
        ///public class ApplicationCreatInstaceEvent : UPPERApplicationEvent { }
        ///public class ApplicationAfterCreatInstaceEvent : UPPERApplicationEvent { }
        ///public class ApplicationInitEndEvent : UPPERApplicationEvent { }
        ///public class ApplicationStoppingEvent : UPPERApplicationEvent { }
        ///public class ApplicationStoppedEvent : UPPERApplicationEvent { }
        ///目前支持事件
        ////// </summary>
        private static ApplicationEventManager _manager;
        /// <summary>
        /// IOC容器
        /// </summary>
        public static IContainerProvider Container { 
            get=> container;
            set => container = value;
        }
        public static ApplicationEventManager EventManager
		{
			get { return _manager; }
			set { _manager = value; }
		}


		public static void RunInstance(MoudleConfiguaion moudle)
        {
			
            InitLog(moudle);
			Container = moudle.Provider;
			RegisterEvent(Container);
            //MoudleConfiguaion model , IContainerProvider prider 
            EventManager.PublishEvent(new ApplicationStartingEvent());
            //    public class  : UPPERApplicationEvent { }
            MoudleInit( moudle);
			
            AppDomain.CurrentDomain.ProcessExit += (sender, e) =>
            {
                ; EventManager.PublishEvent(new ApplicationStoppingEvent());
                EventManager.PublishEvent(new ApplicationStoppedEvent());
            };

            //LoadLog();
        }

        private static void MoudleInit(MoudleConfiguaion moudle)
        {
            var Param = moudle.ExportUpperModel();
            if (!Param.Any(x => x.GetType() == typeof(UPPERIOCMoudle)))
            {
                Param.Add(new UPPERIOCMoudle());
            }
            Param.All(item =>
            {
                item.PreIniter(moudle.Provider);
                return true;
            });

            Param.All(item =>
            {
                item.IniterAndLoadClass(moudle.Provider);
                return true;
            });

            Param.All(item =>
            {
                item.AfterCreateInstance(moudle.Provider);
                return true;
            });
            Param.All(item =>
            {
                item.InitEnd(moudle.Provider);
                return true;
            });
        }

        private static void InitLog(MoudleConfiguaion moudle)
        {
            Log = moudle.Log;
            LogCenter.AddAllLog(Log.ToArray());
        }

        private static void RegisterEvent(IContainerProvider container)
        {
            try
            {
                EventManager = container.GetInstance<ApplicationEventManager>();

                var mainAssembly = AppDomain.CurrentDomain.GetAssemblies()
                 .FirstOrDefault(assembly =>
              assembly.GetTypes().Any(type => type.Name == "IOCGeneratedRegistration"));

                if (mainAssembly != null)
                {
                    var type = mainAssembly.GetType("UPPER.Generated.IOCGeneratedRegistration");
                    var method = type?.GetMethod("RegisterListener", BindingFlags.Public | BindingFlags.Static);
                    if (method != null)
                    {
                        method?.Invoke(null, new object[] { EventManager }); // 调用静态方法
                        Console.WriteLine("RegisterListener invoked successfully.");
                    }

                }
                Console.WriteLine($"RegisterListener Error invoking Fail");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"RegisterListener Error invoking RegisterAll: {ex}");
            }
        }

        public static void RigisterVersionModel(VersionModel vm1) 
		{
			if (vm1.GetType() == typeof(VersionModel) && vm1 != null)
			{
				return;
			}
			vm = vm1;
		}
		/*public static void LoadLog()
		{
			object[] ilog = null;
			ilog = Container?.GetAllInstance(typeof(ILog));
			if ((ilog) != null && ilog.Length > 0)
			{
				LogCenter.AddAllLog(ilog.Select(i => (ILog)i).ToArray());

			}
		}
	*/

	}
}
