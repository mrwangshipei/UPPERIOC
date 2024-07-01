using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpperComAutoTest.View.Page.Interface;
using UPPERIOC.UPPERIOCCenter;

namespace UPPERIOC.UPPERMvvm
{
    public interface IMvvmCompent
	{
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
	}
}
