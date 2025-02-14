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


        public override void AfterCreateInstance(IContainerProvider containerProvider)
		{
         
        }

        public override void PreIniter(IContainerProvider containerProvider)
		{
			    
        }

		public override void InitEnd(IContainerProvider containerProvider)
		{
            ma.PublishEvent(new ApplicationInitEndEvent());

        }
		public override void IniterAndLoadClass(IContainerProvider containerProvider)
        {

             ma=  containerProvider.GetInstance<ApplicationEventManager>();
            ma.PublishEvent(new ApplicationPreCreatInstaceEvent());
            this.containerProvider = containerProvider;
            U.C = containerProvider;
            try
            {

                var mainAssembly = GetAllReferencedAssemblies(Assembly.GetEntryAssembly())
                 .FindAll(assembly => {
                     try
                     {
                         return  assembly.GetTypes().Any(type => type.Name == "IOCGeneratedRegistration");

                     }
                     catch (Exception ex )
                     {
                         return false;
                     }
                  }
              );

                if (mainAssembly != null)
                {
                    foreach (var item in mainAssembly)
                    {
                        var type = item.GetType("UPPER.Generated.IOCGeneratedRegistration");
                        var method = type?.GetMethod("RegisterAll", BindingFlags.Public | BindingFlags.Static);
                        if (method != null)
                        {
                            try
                            {

                                method?.Invoke(null, new object[] { containerProvider }); // 调用静态方法
                                Console.WriteLine("RegisterAll invoked successfully.");
                            }
                            catch (Exception ee)
                            {
                                LogCenter.Log(enums.LogType.Error,"RegisterAll Error:" + ee.Message + ee.StackTrace);

                                Console.WriteLine("RegisterAll Error:" + ee.Message + ee.StackTrace);
                            }
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
        public static List<Assembly> GetAllReferencedAssemblies(Assembly assembly)
        {
            var referencedAssemblies = new HashSet<Assembly>();
            var queue = new Queue<Assembly>();
            queue.Enqueue(assembly);

            while (queue.Count > 0)
            {
                var currentAssembly = queue.Dequeue();
                if (!referencedAssemblies.Contains(currentAssembly))
                {
                    referencedAssemblies.Add(currentAssembly);
                    foreach (var reference in currentAssembly.GetReferencedAssemblies())
                    {
                        try
                        {
                            var referencedAssembly = Assembly.Load(reference);
                            if (!referencedAssemblies.Contains(referencedAssembly))
                            {
                                queue.Enqueue(referencedAssembly);
                            }
                        }
                        catch (Exception ex)
                        {
                            // 忽略找不到的程序集
                        }
                    }
                }
            }

            return referencedAssemblies.ToList();
        }


    }
}
