using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpperComAutoTest.View.Page.Interface;
using UPPERIOC.UPPERIOCCenter;
using UPPERIOC.UPPERMvvm;

namespace UPPERIOC.Interface
{
    public abstract class IVIewModel:IMvvmCompent
    {
        public IVIewModel()
        {
            Create();
        }
        public abstract void Create();

        public abstract void Destroy();
	
		public void Invoke<T>(Action<IMvvmCompent> act) where T : IMvvmCompent
		{
			var obj = UPPERIOCApplication.Container.GetInstance(typeof(T)) as IMvvmCompent;
			if (obj != null)
			{
					act?.Invoke(obj);
				
			}
		}
	}
}
