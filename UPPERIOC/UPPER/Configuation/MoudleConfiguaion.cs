using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.Event.AppEvent;
using UPPERIOC.UPPER.Event.AppEvent.Impl;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.MainApplication.Log_;
using UPPERIOC2.UPPER.UIOC.DefaultProvider;

namespace UPPERIOC.UPPER.IOC.Center.Configuation
{
    public class MoudleConfiguaion
    {
        private readonly List<IUPPERMoudle> _modules = new();
        private readonly List<ILog> _logs = new();
        private IContainerProvider _containerProvider;
        private readonly object _lock = new();

        public ApplicationEventManager EventManager { get; private set; }

        public List<IUPPERMoudle> Modules => _modules;
        public IReadOnlyList<ILog> Logs => _logs;

        public IContainerProvider Provider
        {
            get
            {
                if (_containerProvider == null)
                {
                    lock (_lock)
                    {
                        if (_containerProvider == null)
                        {
                            _containerProvider = new UPPERDefaultProvider();
                            EventManager = _containerProvider.Rigister(new ApplicationEventManager()) as ApplicationEventManager;
                        }
                    }
                }
                return _containerProvider;
            }
            set
            {
                lock (_lock)
                {
                    _containerProvider = value;
                    EventManager = _containerProvider.Rigister(new ApplicationEventManager()) as ApplicationEventManager;
                }
            }
        }

        public void SetProvider<T>() where T : IContainerProvider, new()
        {
            Provider = new T();
        }

        public void AddModule<T>() where T : IUPPERMoudle, new()
        {
            _modules.Add(new T());
        }

        public void AddModule(IUPPERMoudle module)
        {
            if (module != null) _modules.Add(module);
        }

        public void AddLogger<T>() where T : ILog, new()
        {
            _logs.Add(new T());
        }

        public void AddLogger(ILog log)
        {
            if (log != null) _logs.Add(log);
        }

        public static MoudleConfiguaion Configure(Action<MoudleConfiguaion> config)
        {
            var cfg = new MoudleConfiguaion();
            config(cfg);
            return cfg;
        }
    }

}
