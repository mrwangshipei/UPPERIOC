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
using UPPERIOC.UPPER.IOC.DefaultProvider;
using UPPERIOC.UPPER.MainApplication.Log_;
using UPPERIOC.UPPER.Moudle_;


namespace UPPERIOC.UPPER.IOC.Center.Configuation
{
    public class ModuleConfiguaion
    {
        private List<IUPPERModule> _modules = new();
        private readonly List<ILog> _logs = new();
        private IContainerProvider _containerProvider;
        private readonly object _lock = new();
        private ModuleLoader loader;
        public ApplicationEventManager EventManager { get; private set; }

        public List<IUPPERModule> Modules
        {
            get
            {
                loader = new ModuleLoader(_modules);
                _modules = loader.GetLoadOrder();
                return _modules;
            }
        }
        public List<IUPPERModule> UnLoadModules
        {
            get
            {
                loader = new ModuleLoader(_modules);
                _modules = loader.GetUnloadOrder();
                return _modules;
            }
        }
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
            if (_containerProvider != null)
            {
                throw new Exception("SetProvider<T>()函数必须在配置中置顶");
            }
            Provider = new T();
        }

        public void AddModule<T>() where T : IUPPERModule, new()
        {
            _modules.Add(new T());
        }

        public void AddModule(IUPPERModule module)
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

        public static ModuleConfiguaion Configure(Action<ModuleConfiguaion> config)
        {
            var cfg = new ModuleConfiguaion();
            config(cfg);
            return cfg;
        }
    }

}
