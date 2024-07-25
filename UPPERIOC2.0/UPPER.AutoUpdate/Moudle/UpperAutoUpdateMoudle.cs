using System;
using System.Collections.Generic;
using System.Text;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;

namespace UPPERIOC2.UPPER.AutoUpdate.Moudle
{
	public class UpperAutoUpdateMoudle : IUPPERMoudle
	{
		public Type[] DependisMoudel { get => new Type[0]; set { } }

		public void AfterCreateInstance(IContainerProvider containerProvider)
		{
			MainUpdate.InitUpdate( containerProvider);
		}

		public void InitEnd(IContainerProvider containerProvider)
		{
		}

		public void IniterAndLoadClass(IContainerProvider containerProvider)
		{
		}

		public void PreIniter(IContainerProvider containerProvider)
		{
		}
	}
}
