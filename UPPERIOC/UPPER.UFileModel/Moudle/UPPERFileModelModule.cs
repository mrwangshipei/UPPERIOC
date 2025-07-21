using System;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.Sendor.Moudle;
using UPPERIOC2.UPPER.UFileModel.Center;

namespace UPPERIOC2.UPPER.UFileModel.Moudle
{
    public class UPPERFileModelModule : IUPPERModule, IModulePostConstruction, IModuleInitialization, IModulePostInitialization, IModulePreInitialization
    {
        public override Type[] Dependencies { get => new Type[] { }; }

        public void OnPostConstruct(IContainerProvider containerProvider)
		{	

		}

        public void OnPostInitialize(IContainerProvider containerProvider)
		{
		}

        public void OnInitialize(IContainerProvider containerProvider)
		{
		}

        public void OnPreInitialize(IContainerProvider containerProvider)
		{
			UFileModelCenter.pdr = containerProvider;
			UFileModelCenter.Instance = new UFileModelCenter();

            containerProvider.Rigister<UFileModelCenter>(UFileModelCenter.Instance);
			//UFileModelCenter.Instance = new UFileModelCenter();
		}
	}
}
