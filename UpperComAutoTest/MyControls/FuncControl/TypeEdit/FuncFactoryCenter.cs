using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UpperComAutoTest.Entry.IEventFileModel.IMsgEvent;
using UpperComAutoTest.MyControls.FuncControl.TypeEdit.IFactory;
using UPPERIOC.UPPER.IOC.Annaiation;

namespace UpperComAutoTest.MyControls.FuncControl.TypeEdit
{
	public class FuncFactoryCenter
	{
		public static FuncFactoryCenter Instance = new FuncFactoryCenter();
		IFuncFactory[] funcf;
		public FuncFactoryCenter() {
			funcf  = Assembly.GetEntryAssembly().GetTypes().Where(item => item.GetInterfaces().Contains(typeof(IFuncFactory))).Select(item=> Assembly.GetAssembly(item).CreateInstance(item.FullName) as IFuncFactory).ToArray();
		}
		public string[] GetFuncItemName()
		{
			return funcf.Select(item=> item.ProductName).ToArray(); ;

		}
		public IFuncTypeEdit CreatFuncControl(MsgEventInterface eventmsg)
		{
			return funcf.FirstOrDefault(item => item.ProductType == eventmsg.GetType()).CreateIFuncControl(eventmsg);
		}
		public IFuncTypeEdit CreatFuncControl(string funname)
		{
			return funcf.FirstOrDefault(item => item.ProductName == funname).CreateIFuncControl();
		}

		internal string GetFactryName(MsgEventInterface msgeve)
		{
			return funcf.FirstOrDefault(item => item.ProductType == msgeve.GetType())?.ProductName;        
		}
	}
}
