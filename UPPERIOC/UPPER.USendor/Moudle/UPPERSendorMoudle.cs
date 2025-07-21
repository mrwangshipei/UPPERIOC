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
    public class UPPERSendorMoudle : IUPPERModule, IModulePostConstruction, IModuleInitialization, IModulePostInitialization, IModulePreInitialization
    {

        public UPPERSendorMoudle()
        {

        }

        public override Type[] Dependencies { get => new Type[] { }; }


        public void OnPostConstruct(IContainerProvider containerProvider)
		{
			SendorCenter.Contain = containerProvider;

		}

        public void OnPreInitialize(IContainerProvider containerProvider)
		{
		}

        public void OnPostInitialize(IContainerProvider containerProvider)
		{
		}

        public void OnInitialize(IContainerProvider containerProvider)
		{
		}
	}
}
