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
        List<Type> Moudle = new List<Type>();
        List<Type> Log = new List<Type>();
		internal IContainerProvider _containerProvider;
        public void SetProvider<T>() where T: IContainerProvider 
        {
			_containerProvider = (T)typeof(T).GetConstructors().First().Invoke(null);
		}
		public void AddMoudle<T>()where T : IUPPERMoudle
		{
            Moudle.Add(typeof(T));
        }
		public void AddILog<T>() where T : ILog
		{
			Log.Add(typeof(T));
		}
		internal IUPPERMoudle[] ExportUpperModel() {
            IUPPERMoudle[] models = new IUPPERMoudle[Moudle.Count];
            return Moudle.Select(model =>
            {

                return model.Assembly.CreateInstance(model.FullName) as IUPPERMoudle;
            }).ToArray();
		}
    }
}
