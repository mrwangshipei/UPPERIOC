
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpperComAutoTest.ModelView._IViewModel;

namespace UpperComAutoTest.View.Page.Interface
{
	public class IPage : UserControl
	{

        public virtual string PageName { get => Name; }

		public virtual IVIewModel ViewModel { get; set; }

		public IPage(IVIewModel viewm) {
			this.ViewModel = viewm;
		}
		protected override void DestroyHandle()
		{
			base.DestroyHandle();
			ViewModel?.Destroy();
		}
	}
}
