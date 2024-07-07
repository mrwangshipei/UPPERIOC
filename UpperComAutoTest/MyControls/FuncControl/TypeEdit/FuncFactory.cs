using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPERIOCCenter;

namespace UpperComAutoTest.MyControls.FuncControl.TypeEdit
{
	public class FuncFactory
	{
		public static FuncFactory Instance = new FuncFactory();
		public string[] GetFuncItemName() 
		{
			var obs = UPPERIOCContain.Container.GetAllInstance(typeof(IFuncTypeEdit));
			
		}

	}
}
