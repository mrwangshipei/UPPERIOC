// 监听者类：监听所有生命周期事件
using System.Collections.Generic;
using System;
using UPPERIOC.UPPER.Event.AppEvent.Impl;
using UPPERIOC;
using Xunit;
using System.IO;
using UPPERIOC2.UPPER.UIOC.Center;
using System.Linq;
using System.Diagnostics;

namespace UPPER.Test.ApplicationEventTests { 
    public class ProgramEntry
    {

        public class FullLifecycleListener :
        IUPPERApplicationListener<ApplicationPreInitializationEvent>,
        IUPPERApplicationListener<ApplicationModuleInitializedEvent>,
        IUPPERApplicationListener<ApplicationModulePreCreationEvent>,
        IUPPERApplicationListener<ApplicationInstanceCreatedEvent>,
        IUPPERApplicationListener<ApplicationInitEndEvent>,
        IUPPERApplicationListener<ApplicationStoppingEvent>,
        IUPPERApplicationListener<ApplicationStoppedEvent>
        {
            private readonly List<string> _eventLog;

            public FullLifecycleListener(List<string> eventLog)
            {
                _eventLog = eventLog;
            }

            public string MoudleName => "FullLifecycleListener";

            public void OnEvent(ApplicationPreInitializationEvent e) => _eventLog.Add(nameof(ApplicationPreInitializationEvent));
            public void OnEvent(ApplicationModuleInitializedEvent e) => _eventLog.Add(nameof(ApplicationModuleInitializedEvent));
            public void OnEvent(ApplicationModulePreCreationEvent e) => _eventLog.Add(nameof(ApplicationModulePreCreationEvent));
            public void OnEvent(ApplicationInstanceCreatedEvent e) => _eventLog.Add(nameof(ApplicationInstanceCreatedEvent));
            public void OnEvent(ApplicationInitEndEvent e) => _eventLog.Add(nameof(ApplicationInitEndEvent));
            public void OnEvent(ApplicationStoppingEvent e) => _eventLog.Add(nameof(ApplicationStoppingEvent));
            public void OnEvent(ApplicationStoppedEvent e) => _eventLog.Add(nameof(ApplicationStoppedEvent));
        }

        private static List<string> _eventLog = new List<string>();
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                return;
            }
            var tpfile = args[0];
           // var tpfile = "C://x.txt";  // 输出的文件路径
            _eventLog.Clear();

            UPPERIOCApplication.RunInstance(md => { }, e => {
                // 注册监听器
                e.RegisterListener<ApplicationPreInitializationEvent>(new FullLifecycleListener(_eventLog));
            });

            // 依生命周期顺序触发事件
            AppDomain.CurrentDomain.ProcessExit += (__, ___) => {
                // 预期触发顺序
                var expectedOrder = new List<string>
        {
            nameof(ApplicationPreInitializationEvent),
            nameof(ApplicationModuleInitializedEvent),
            nameof(ApplicationModulePreCreationEvent),
            nameof(ApplicationInstanceCreatedEvent),
            nameof(ApplicationInitEndEvent),
            nameof(ApplicationStoppingEvent),
            nameof(ApplicationStoppedEvent)
        };

                // 验证触发顺序与预期一致
                Assert.Equal(expectedOrder, _eventLog); // 这里你可以添加断言或其它验证逻辑
                File.WriteAllText(tpfile, "ok");

                // 将事件顺序写入文件
            };
        }
}
}