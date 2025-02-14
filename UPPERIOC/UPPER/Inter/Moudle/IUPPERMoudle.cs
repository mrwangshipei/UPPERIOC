using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Center.IProvider;

namespace UPPERIOC.UPPER.IOC.Center.Interface
{
    public abstract class IUPPERMoudle: Attribute
    {
        Type[] DependisMoudel { get; set; }
        //public static IUPPERContainIniter Instance { get; set; }
        public abstract void AfterCreateInstance(IContainerProvider containerProvider);
        public abstract void PreIniter(IContainerProvider containerProvider);
        public abstract void InitEnd(IContainerProvider containerProvider);
        public abstract void IniterAndLoadClass(IContainerProvider containerProvider);
	}
}
