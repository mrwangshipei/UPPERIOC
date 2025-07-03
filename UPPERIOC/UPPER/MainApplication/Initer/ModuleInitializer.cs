using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Center.Configuation;
using UPPERIOC.UPPER.IOC.Moudle;

namespace UPPERIOC.UPPER.MainApplication.Initer
{
    public static class ModuleInitializer
    {
        public static void InitModules(MoudleConfiguaion config)
        {
            var modules = config.Modules ;
            modules.RemoveAll(x => x is UPPERIOCMoudle); // 主模块留在外部控制

            var core = new UPPERIOCMoudle();
            core.PreIniter(config.Provider);
            modules.ForEach(m => m.PreIniter(config.Provider));

            core.IniterAndLoadClass(config.Provider);
            modules.ForEach(m => m.IniterAndLoadClass(config.Provider));

            core.AfterCreateInstance(config.Provider);
            modules.ForEach(m => m.AfterCreateInstance(config.Provider));

            core.InitEnd(config.Provider);
            modules.ForEach(m => m.InitEnd(config.Provider));
        }
    }

}
