using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.UFileLog.IConfiguation;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.IOC.Moudle;
using UPPERIOC.UPPER.UFileLog.DefineLog;
using UPPERIOC.UPPER.IOC.Center.Interface;

namespace UPPERIOC.UPPER.UFILELOG.Moudle
{
    public class UPPERLogFileMoudle : IUPPERMoudle
	{
		IContainerProvider containerProvider;
		public Type[] DependisMoudel { get; set; } = new Type[] { } ;

        public override void AfterCreateInstance(IContainerProvider containerProvider)
		{
			var con = (IFileLogConfiguation)containerProvider.GetInstance(typeof(IFileLogConfiguation));
			LogCenter.AddILog(containerProvider.Rigister<FileLog>());

		}

        public override void PreIniter(IContainerProvider containerProvider)
		{

		}

        public override void InitEnd(IContainerProvider containerProvider)
		{

		}


        public override void IniterAndLoadClass(IContainerProvider containerProvider)
		{
			this.containerProvider = containerProvider;

		}
	}
}
