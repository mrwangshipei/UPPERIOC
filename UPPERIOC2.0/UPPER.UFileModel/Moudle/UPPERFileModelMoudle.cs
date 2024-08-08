using System;
using System.Collections.Generic;
using System.Text;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.Sendor.Moudle;
using UPPERIOC2.UPPER.UFileModel.Center;

namespace UPPERIOC2.UPPER.UFileModel.Moudle
{
	public class UPPERFileModelMoudle : IUPPERMoudle
	{
		public Type[] DependisMoudel { get => new Type[0]; set => throw new NotImplementedException(); }

		public void AfterCreateInstance(IContainerProvider containerProvider)
		{	

		}

		public void InitEnd(IContainerProvider containerProvider)
		{
		}

		public void IniterAndLoadClass(IContainerProvider containerProvider)
		{
		}

		public void PreIniter(IContainerProvider containerProvider)
		{
			UFileModelCenter.pdr = containerProvider;

			//UFileModelCenter.Instance = new UFileModelCenter();
		}
	}
}
