using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Center.IProvider;

namespace UPPERIOC.UPPER.IOC.Center.Interface
{
    public interface IUPPERMoudle
    {
         Type[] DependisMoudel { get; set; }
        //public static IUPPERContainIniter Instance { get; set; }
        void AfterCreateInstance(IContainerProvider containerProvider);
         void PreIniter(IContainerProvider containerProvider);
         void InitEnd(IContainerProvider containerProvider);
		void IniterAndLoadClass(IContainerProvider containerProvider);
	}
}
