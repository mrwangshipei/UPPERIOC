using System;
using System.Collections.Generic;
using System.Text;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC2.UPPER.Premission.Center;

namespace UPPERIOC2.UPPER.Premission.Moudle
{
	internal class UPPERPremissionMoudle : IUPPERMoudle
	{
		public Type[] DependisMoudel { get => new Type[0]; set => throw new NotImplementedException(); }

		public void AfterCreateInstance(IContainerProvider containerProvider)
		{
			PremissionCenter.pd = containerProvider;
			var cen = PremissionCenter.pd.Rigister<PremissionCenter>();
			cen.LoadUser();
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
