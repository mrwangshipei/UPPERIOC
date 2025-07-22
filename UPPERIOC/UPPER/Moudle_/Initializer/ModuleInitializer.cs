using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.Event.AppEvent.Impl;
using UPPERIOC.UPPER.IOC.Center.Configuation;
using UPPERIOC.UPPER.IOC.Moudle;
using UPPERIOC2.UPPER.UIOC.Center;

namespace UPPERIOC.UPPER.Moudle_.Initializer
{
    public static class ModuleInitializer
    {
        public static void InitModules(ModuleConfiguaion config)
        {
            var modules = config.Modules ;
            modules.RemoveAll(x => x is UPPERIOCModule); // 主模块留在外部控制

            var core = new UPPERIOCModule();
            core.OnPreInitialize(config.Provider);
            modules.ForEach(m => {
                if (m is IModulePreInitialization i)
                {
                    i.OnPreInitialize(config.Provider);
                }
            });
            U.E.PublishEvent(new ApplicationModuleInitializedEvent());

            core.OnInitialize(config.Provider);
            modules.ForEach(m => {
                if (m is IModuleInitialization i)
                {
                    i.OnInitialize(config.Provider);
                }
            });
            U.E.PublishEvent(new ApplicationModulePreCreationEvent());

            core.OnPostConstruct(config.Provider);
            modules.ForEach(m => {
                if (m is IModulePostConstruction i)
                {
                    i.OnPostConstruct(config.Provider);
                }
            });
            U.E.PublishEvent(new ApplicationInstanceCreatedEvent());

            core.OnPostInitialize(config.Provider);
            modules.ForEach(m => {
                if (m is IModulePostInitialization i)
                {
                    i.OnPostInitialize(config.Provider);
                }
            });
            U.E.PublishEvent(new ApplicationInitEndEvent());
        }
        
    }

}
