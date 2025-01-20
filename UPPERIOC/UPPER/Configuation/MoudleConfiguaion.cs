using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.Event.AppEvent;
using UPPERIOC.UPPER.Event.AppEvent.Impl;
using UPPERIOC.UPPER.ILOG;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC2.UPPER.UIOC.DefaultProvider;

namespace UPPERIOC.UPPER.IOC.Center.Configuation
{
    public class MoudleConfiguaion
    {
        List<IUPPERMoudle> Moudle = new List<IUPPERMoudle>();
        internal List<ILog> Log = new List<ILog>();
        IContainerProvider _containerProvider;

        public ApplicationEventManager EventManager { get; private set; }

        public IContainerProvider Provider
        {
            get {
                lock (this)
                {
                    if (_containerProvider == null)
                    {
                        lock (this)
                        {

                            _containerProvider = new UPPERDefaultProvider();
                            EventManager = _containerProvider.Rigister<ApplicationEventManager>(new ApplicationEventManager()) as ApplicationEventManager;
                        }
                    }

                }
                return _containerProvider;
            }
            set {
                lock (this)
                {
                    if (_containerProvider == null)
                    {
                        lock (this)
                        {
                            _containerProvider = value;
                            EventManager = _containerProvider.Rigister<ApplicationEventManager>(new ApplicationEventManager()) as ApplicationEventManager;
                        }
                    }
                }

            }
        }
        /// <summary>
        /// 使用默认的IOC管理或者集成其他IOC容器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void SetProvider<T>() where T : IContainerProvider, new()
        {
            Provider = new T();

        }
        //  public void AddListener<T>(IUPPERApplicationListener<T> listener) where T : IUPPERApplicationEvent, new()
        // {
        //    var man = Provider.GetInstance<ApplicationEventManager>();
        //    man.RegisterListener(listener);
        // }
        /// <summary>
        /// 注册一个模块
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void AddMoudle<T>() where T : IUPPERMoudle, new()
        {
            Moudle.Add(new T());
        }
        /// <summary>
        /// 注册一个日志接口
        /// </summary>
        /// <typeparam name="T"></typeparam>
		public void AddILog<T>() where T : ILog, new()
        {
            Log.Add(new T());
        }
        internal List<IUPPERMoudle> ExportUpperModel() {
            //IUPPERMoudle[] models = new IUPPERMoudle[Moudle.Count];
            return Moudle;
        }
        ~MoudleConfiguaion()
        {
           
        }
    }
}
