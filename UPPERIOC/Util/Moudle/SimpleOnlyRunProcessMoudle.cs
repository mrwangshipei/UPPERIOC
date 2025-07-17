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
    public class SimpleOnlyRunProcessMoudle : IUPPERModule, IModulePostConstruction, IModuleInitialization, IModulePostInitialization, IModulePreInitialization
    {
        public override Type[] Dependencies { get => new Type[] { }; }

        public void OnPostConstruct(IContainerProvider containerProvider)
		{
		}

        public void OnPostInitialize(IContainerProvider containerProvider)
		{
		}

        public void OnInitialize(IContainerProvider containerProvider)
		{
		}
		[DllImport("USER32.DLL")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);
        public void OnPreInitialize(IContainerProvider containerProvider)
		{
			if (Process.GetProcesses().Select(item => item.ProcessName).Count(item => item == Process.GetCurrentProcess().ProcessName) > 1)
			{
				SetForegroundWindow(Process.GetProcesses().Where(item => item.ProcessName == Process.GetCurrentProcess().ProcessName).FirstOrDefault().MainWindowHandle);
				Process.GetCurrentProcess().Kill();
			}
		}
	}
}
