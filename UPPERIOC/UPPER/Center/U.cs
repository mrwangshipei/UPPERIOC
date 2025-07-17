using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.Event.AppEvent;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.MainApplication.Dispatcher;

namespace UPPERIOC2.UPPER.UIOC.Center
{
	public static class U 
	{
		public static ApplicationEventManager E 
		{ 
			get 
			{
				return _e;
			}
		}
		internal static ApplicationEventManager _e { get; set; }
		public static IContainerProvider C { get; internal set; }
	}
}
