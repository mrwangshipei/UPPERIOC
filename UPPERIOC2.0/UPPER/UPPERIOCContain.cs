using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using UPPERIOC.UPPER;
using UPPERIOC.UPPER.ILOG;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.IOC.Center.Configuation;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.IOC.Extend;

namespace UPPERIOC.UPPERIOCCenter
{
    //public delegate void DosomethingWhenInited(Dictionary<Type, object> Contain);
    public class UPPERIOCContain
    {
        public static IContainerProvider Container;
        List<ILog> Log = new List<ILog>();
		//public static event DosomethingWhenInited AopEvent;
		public static void RunInstance(MoudleConfiguaion moudle)
        {
			var Param = moudle.ExportUpperModel();
            Container = moudle._containerProvider;
			if (!Param.All(item => Param.Select(item1=> item1.GetType()).ToArray().ContainsAll(item.DependisMoudel)))
			{
				throw new System.Exception("有模块的依赖模块没有加载。");
			}
			//MoudleConfiguaion model , IContainerProvider prider 
			Param.All(item =>
            {
				item.PreIniter(moudle._containerProvider);
                return true;
            });

			Param.All(item =>
			{
				item.IniterAndLoadClass(moudle._containerProvider);
				return true;
			});
		
            Param.All(item =>
            {
                item.AfterCreateInstance(moudle._containerProvider);
                return true;
            });	
            Param.All(item =>
            {
                item.InitEnd(moudle._containerProvider);
                return true;
            });
			LoadLog();

		}

		private static void LoadLog()
		{
			object[] ilog = null;
			ilog = Container?.GetAllInstance(typeof(ILog));
			if ((ilog) != null && ilog.Length > 0)
			{
				LogCenter.AddAllLog(ilog.Select(i => (ILog)i).ToArray());

			}
		}


	}
}
