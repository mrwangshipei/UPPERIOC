using System;
using System.Collections.Generic;
using System.Linq;
using UPPERIOC.UPPER.IOC.Center.Interface;

namespace UPPERIOC.UPPER.Moudle_
{
    public class ModuleLoader
    {
        private enum VisitState { NotVisited, Visiting, Visited }

        private readonly Dictionary<Type, IUPPERModule> _moduleMap;
        private readonly Dictionary<Type, VisitState> _visitStates = new();
        private readonly List<IUPPERModule> _sortedModules = new();

        public ModuleLoader(List<IUPPERModule> modules)
        {
            _moduleMap = modules.ToDictionary(m => m.GetType(), m => m);
        }

        /// <summary>
        /// 获取模块的加载顺序（拓扑顺序）
        /// </summary>
        public List<IUPPERModule> GetLoadOrder()
        {
            _visitStates.Clear();
            _sortedModules.Clear();

            foreach (var module in _moduleMap.Values)
            {
                Visit(module);
            }

            return new List<IUPPERModule>(_sortedModules);
        }

        /// <summary>
        /// 获取模块的注销顺序（反向拓扑顺序）
        /// </summary>
        public List<IUPPERModule> GetUnloadOrder()
        {
            return GetLoadOrder().AsEnumerable().Reverse().ToList();
        }

        private void Visit(IUPPERModule module)
        {
            var type = module.GetType();

            if (_visitStates.TryGetValue(type, out var state))
            {
                if (state == VisitState.Visited)
                    return;
                if (state == VisitState.Visiting)
                    throw new Exception($"模块 {type.Name} 存在循环依赖");
            }

            _visitStates[type] = VisitState.Visiting;

            foreach (var depType in module.Dependencies ?? Array.Empty<Type>())
            {
                if (!_moduleMap.TryGetValue(depType, out var depModule))
                {
                    throw new Exception($"模块 {type.Name} 依赖的模块 {depType.Name} 未在模块列表中注册");
                }

                Visit(depModule);
            }

            _visitStates[type] = VisitState.Visited;
            _sortedModules.Add(module); // 加入结果（拓扑顺序）
        }
    }
}
