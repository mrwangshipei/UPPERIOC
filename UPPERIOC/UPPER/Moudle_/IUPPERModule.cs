using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Center.IProvider;

namespace UPPERIOC.UPPER.Moudle_
{
    public abstract class IUPPERModule
    {
        public abstract Type[] Dependencies { get; }
	}

    // 阶段接口（按执行顺序）

    public interface IModulePostConstruction
    {
        void OnPostConstruct(IContainerProvider provider);
    }
    public interface IModulePreDestruction
    {
        void OnPreDestroy(IContainerProvider provider);
    }

    public interface IModulePreInitialization
    {
        void OnPreInitialize(IContainerProvider provider);
    }

    public interface IModuleInitialization
    {
        void OnInitialize(IContainerProvider provider);
    }

    public interface IModulePostInitialization
    {
        void OnPostInitialize(IContainerProvider provider);
    }
}
