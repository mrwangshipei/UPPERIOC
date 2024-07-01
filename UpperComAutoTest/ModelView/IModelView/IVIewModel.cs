using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpperComAutoTest.ModelView._IViewModel
{
	public abstract class IVIewModel
	{
		public IVIewModel() {
			Create();		
		}
		public abstract void Create();

		public abstract void Destroy();
	}
}
