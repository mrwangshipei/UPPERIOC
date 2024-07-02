
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.Interface;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPERIOCCenter;
using UPPERIOC.UPPERMvvm;

namespace UpperComAutoTest.View.Page.Interface
{
    
	public class IPage : UserControl, IMvvmCompent
	{

        public virtual string PageName { get => GetType().Name; }

		public virtual IVIewModel ViewModel { get; set; }
		public IPage() {
			this.ViewModel = default(IVIewModel);
		}
		public IPage(IVIewModel viewm) {
			this.ViewModel = viewm;
		}
		protected override void DestroyHandle()
		{
			base.DestroyHandle();
			ViewModel?.Destroy();
		}
		public void Invoke<T>(Action<IMvvmCompent> act) where T : IMvvmCompent
		{
			var obj = UPPERIOCContain.Container.GetInstance(typeof(T)) as IPage;
			if (obj != null)
			{
				obj.Invoke(() => {
					act?.Invoke(obj);
				});
			}
		}

		public void Invoke<T>(Action<IVIewModel> act) where T : IVIewModel
		{
			var obj = UPPERIOCContain.Container.GetInstance(typeof(T)) as IVIewModel;
			if (obj != null)
			{
					act?.Invoke(obj);
			}
		}
	}
}
