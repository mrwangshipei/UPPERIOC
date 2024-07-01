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
        //public static IUPPERContainIniter Instance { get; set; }
        public void AfterCreateInstance(IContainerProvider containerProvider);
        public void PreIniter(IContainerProvider containerProvider);
        public void InitEnd(IContainerProvider containerProvider);
		void IniterAndLoadClass(IContainerProvider containerProvider);
	}
}
