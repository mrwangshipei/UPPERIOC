using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.UFileLog.IConfiguation;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.UFileLog;

namespace UPPERIOC.UPPER.IOC.Moudle
{
    public class UPPERLogFileMoudle : IUPPERMoudle
	{
		
		public void AfterCreateInstance(IContainerProvider containerProvider)
		{
			var con = (IFileLogConfiguation)containerProvider.GetInstance(typeof(IFileLogConfiguation));
			containerProvider.Rigister<FileLog>();
		}

		public void PreIniter(IContainerProvider containerProvider)
		{

		}

		public void InitEnd(IContainerProvider containerProvider)
		{

		}
		IContainerProvider containerProvider;
		public void IniterAndLoadClass(IContainerProvider containerProvider)
		{
			this.containerProvider = containerProvider;

		}
	}
}
