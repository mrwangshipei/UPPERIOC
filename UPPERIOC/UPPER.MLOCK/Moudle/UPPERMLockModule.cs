using System;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC2.UPPER.MLOCK.IConfiguation;
using UPPERIOC2.UPPER.Util;

namespace UPPERIOC.UPPER.IOC.Moudle
{
    public class UPPERMLockModule : IUPPERModule, IModulePostConstruction, IModuleInitialization, IModulePostInitialization, IModulePreInitialization
    {

		public override Type[] Dependencies { get; } = new Type[0];
		
		public static	MLockConfiguation m;
		public void OnPostConstruct(IContainerProvider containerProvider)
		{
			var c = containerProvider.GetAllInstance<MLockConfiguation>();
			if (c.Length <= 0)
			{
				throw new Exception("至少注册一个MLockConfiguation的对象");
			}
			m = c[0];
			if (RegisterHelper.Instance.GetLockFile(m.Listenaddr,m.LockName) == null)
			{
				m.Noregister();

			}
			if (HashHelper.VerifyWithSalt(m.Solt , RegisterHelper.Instance.GetLockFile( m.Listenaddr, m.LockName)))
			{
				Console.Write("验证成功");
			}
			else
			{
				m.Noregister();
		

			}

		}

        public void OnPreInitialize(IContainerProvider containerProvider)
		{
			
		}

        public void OnPostInitialize(IContainerProvider containerProvider)
		{

		}
		IContainerProvider containerProvider;
        public void OnInitialize(IContainerProvider containerProvider)
		{

		}


	
	}

}
