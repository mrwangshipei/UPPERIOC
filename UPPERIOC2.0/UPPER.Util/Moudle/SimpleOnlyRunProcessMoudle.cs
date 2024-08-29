using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;

namespace UPPERIOC2.UPPER.Util.Moudle
{
	internal class SimpleOnlyRunProcessMoudle : IUPPERMoudle
	{
		public Type[] DependisMoudel { get => Type.EmptyTypes; set => throw new NotImplementedException(); }

		public void AfterCreateInstance(IContainerProvider containerProvider)
		{
		}

		public void InitEnd(IContainerProvider containerProvider)
		{
		}

		public void IniterAndLoadClass(IContainerProvider containerProvider)
		{
		}
		[DllImport("USER32.DLL")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);
		public void PreIniter(IContainerProvider containerProvider)
		{
			if (Process.GetProcesses().Select(item => item.ProcessName).Count(item => item == Process.GetCurrentProcess().ProcessName) > 1)
			{
				SetForegroundWindow(Process.GetProcesses().Where(item => item.ProcessName == Process.GetCurrentProcess().ProcessName).FirstOrDefault().MainWindowHandle);
				Process.GetCurrentProcess().Kill();
			}
		}
	}
}
