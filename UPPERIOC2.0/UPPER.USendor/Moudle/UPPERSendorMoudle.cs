using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;


namespace UPPERIOC.UPPER.Sendor.Model
{
	public class UPPERSendorMoudle : IUPPERMoudle
    {

        public UPPERSendorMoudle()
        {

        }

     

		public void AfterCreateInstance(IContainerProvider containerProvider)
		{
			Sendor.Contain = containerProvider;

		}

		public void PreIniter(IContainerProvider containerProvider)
		{
		}

		public void InitEnd(IContainerProvider containerProvider)
		{
		}

		public void IniterAndLoadClass(IContainerProvider containerProvider)
		{
		}
	}
}
