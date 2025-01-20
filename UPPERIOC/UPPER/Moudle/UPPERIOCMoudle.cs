using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.Event.AppEvent;
using UPPERIOC.UPPER.Event.AppEvent.Impl;
using UPPERIOC.UPPER.ILOG;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.IOC.Extend;
using UPPERIOC2.UPPER.UIOC.Center;

namespace UPPERIOC.UPPER.IOC.Moudle
{
    public class UPPERIOCMoudle : IUPPERMoudle
	{
        ApplicationEventManager ma;
        IContainerProvider containerProvider;

		public Type[] DependisMoudel { get; set; } = new Type[0];


        public void AfterCreateInstance(IContainerProvider containerProvider)
		{
         
        }

		public void PreIniter(IContainerProvider containerProvider)
		{
			    
        }

		public void InitEnd(IContainerProvider containerProvider)
		{
            ma.PublishEvent(new ApplicationInitEndEvent());

        }
		public void IniterAndLoadClass(IContainerProvider containerProvider)
        {

             ma=  containerProvider.GetInstance<ApplicationEventManager>();
            ma.PublishEvent(new ApplicationPreCreatInstaceEvent());
            this.containerProvider = containerProvider;
            U.C = containerProvider;
            try
            {

                var mainAssembly = AppDomain.CurrentDomain.GetAssemblies()
                 .ToList().FindAll(assembly =>
              assembly.GetTypes().Any(type => type.Name == "IOCGeneratedRegistration"));

                if (mainAssembly != null)
                {
                    foreach (var item in mainAssembly)
                    {
                        var type = item.GetType("UPPER.Generated.IOCGeneratedRegistration");
                        var method = type?.GetMethod("RegisterAll", BindingFlags.Public | BindingFlags.Static);
                        if (method != null)
                        {
                            method?.Invoke(null, new object[] { containerProvider }); // 调用静态方法
                            Console.WriteLine("RegisterAll invoked successfully.");
                        }
                        
                    }

                }
                Console.WriteLine($"Error invoking Fail");
                ma.PublishEvent(new ApplicationAfterCreatInstaceEvent());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error invoking RegisterAll: {ex}");
            }
        }


    }
}
