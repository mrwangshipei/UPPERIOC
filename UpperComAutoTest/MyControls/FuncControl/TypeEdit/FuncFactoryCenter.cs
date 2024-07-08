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
	public class FuncFactoryCenter
	{
		public static FuncFactoryCenter Instance = new FuncFactoryCenter();
		internal string[] GetFuncItemName()
		{
			return UPPERIOCContain.Container.GetAllInstance(typeof(IFuncTypeEdit)).Select(item => (item as IFuncTypeEdit).Name).ToArray();

		}
		internal IFuncTypeEdit CreatFuncControl(string Name)
		{
			
		}
	}
}
