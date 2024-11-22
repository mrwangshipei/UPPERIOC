using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.ILOG;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;

namespace UPPERIOC.UPPER.IOC.Center.Configuation
{
    public class MoudleConfiguaion
    {
        List<IUPPERMoudle> Moudle = new List<IUPPERMoudle>();
        internal List<ILog> Log = new List<ILog>();
		public IContainerProvider _containerProvider ;
        /// <summary>
        /// 使用默认的IOC管理或者集成其他IOC容器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void SetProvider<T>() where T: IContainerProvider ,new()
        {
			_containerProvider = new T();
		}
        /// <summary>
        /// 注册一个模块
        /// </summary>
        /// <typeparam name="T"></typeparam>
		public void AddMoudle<T>()where T : IUPPERMoudle,new()
		{
            Moudle.Add(new T());
        }
        /// <summary>
        /// 注册一个日志接口
        /// </summary>
        /// <typeparam name="T"></typeparam>
		public void AddILog<T>() where T : ILog,new()
		{
			Log.Add(new T());
		}
		internal IUPPERMoudle[] ExportUpperModel() {
            //IUPPERMoudle[] models = new IUPPERMoudle[Moudle.Count];
            return Moudle.ToArray();
		}
    }
}
