//// 监听者类：监听所有生命周期事件
//using System.Collections.Generic;
//using System;
//using UPPERIOC.UPPER.Event.AppEvent.Impl;
//using UPPERIOC;
//using Xunit;
//using System.IO;
//using UPPERIOC2.UPPER.UIOC.Center;
//using System.Linq;
//using System.Diagnostics;
//using System;

using UPPERIOC;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;

namespace UPPER.Test.ApplicationEventTests
{
    public class ProgramML
    {


        public class UPPERMLifecycleValidatorModule : IUPPERModule,
            IModulePreInitialization,
            IModuleInitialization,
            IModulePostInitialization,
            IModulePostConstruction,
            IModulePreDestruction
        {
            public static List<string> LifecycleLog { get; } = new();

            public override Type[] Dependencies => null;

            public void OnPostConstruct(IContainerProvider provider)
            {
                LifecycleLog.Add("OnPostConstruct");
                Console.WriteLine("模块生命周期：OnPostConstruct");
            }

            public void OnPreInitialize(IContainerProvider provider)
            {
                LifecycleLog.Add("OnPreInitialize");
                Console.WriteLine("模块生命周期：OnPreInitialize");
            }

            public void OnInitialize(IContainerProvider provider)
            {
                LifecycleLog.Add("OnInitialize");
                Console.WriteLine("模块生命周期：OnInitialize");
            }

            public void OnPostInitialize(IContainerProvider provider)
            {
                LifecycleLog.Add("OnPostInitialize");
                Console.WriteLine("模块生命周期：OnPostInitialize");
            }

            public void OnPreDestroy(IContainerProvider provider)
            {
                LifecycleLog.Add("OnPreDestroy");
                Console.WriteLine("模块生命周期：OnPreDestroy");
            }
        }
        public static void Main(string[] orgs)
        {
            if (orgs.Length != 1)
            {
                throw new Exception("未从正确的入口点进入代码");
            }
            UPPERIOCApplication.RunInstance(md => {
                md.AddModule<UPPERMLifecycleValidatorModule>();
            });
            AppDomain.CurrentDomain.ProcessExit += (__, ___) => {
                if (UPPERMLifecycleValidatorModule.LifecycleLog.Count != 5)
                {
                    throw new Exception("模块生命周期未正确执行");
                }
                var li = new List<string>() { "OnPreInitialize", "OnInitialize", "OnPostConstruct", "OnPostInitialize", "OnPreDestroy", };
                if (!UPPERMLifecycleValidatorModule.LifecycleLog.SequenceEqual(li))
                {
                    throw new Exception("模块生命周期执行顺序错误");
                }
                File.WriteAllText(orgs[0],"ok");
            };
        }
    }
}