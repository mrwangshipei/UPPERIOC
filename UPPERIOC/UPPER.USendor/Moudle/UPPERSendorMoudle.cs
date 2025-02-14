using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC2.UPPER.USendor.Center;


namespace UPPERIOC.UPPER.Sendor.Moudle
{
    public class UPPERSendorMoudle : IUPPERMoudle
    {

        public UPPERSendorMoudle()
        {

        }

		public Type[] DependisMoudel { get; set; } = new Type[0];


        public override void AfterCreateInstance(IContainerProvider containerProvider)
		{
			SendorCenter.Contain = containerProvider;

		}

        public override void PreIniter(IContainerProvider containerProvider)
		{
		}

        public override void InitEnd(IContainerProvider containerProvider)
		{
		}

        public override void IniterAndLoadClass(IContainerProvider containerProvider)
		{
		}
	}
}
