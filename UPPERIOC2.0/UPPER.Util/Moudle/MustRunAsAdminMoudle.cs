using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using System.Text;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;

namespace UPPERIOC2.UPPER.Util.Moudle
{
	internal class MustRunAsAdminMoudle : IUPPERMoudle
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

		public void PreIniter(IContainerProvider containerProvider)
		{
			// 检查当前用户是否具有管理员权限
			if (!IsRunAsAdmin())
			{
				// 如果没有管理员权限，则重新启动程序并请求提升权限
				RunAsAdmin();
				Process.GetCurrentProcess().Kill();
			}

		}
		private static bool IsRunAsAdmin()
		{
			try
			{
				WindowsIdentity id = WindowsIdentity.GetCurrent();
				WindowsPrincipal principal = new WindowsPrincipal(id);
				return principal.IsInRole(WindowsBuiltInRole.Administrator);
			}
			catch (UnauthorizedAccessException ex)
			{
				return false;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		// 重新启动程序并请求提升权限
		private static void RunAsAdmin()
		{
			var exeName = Process.GetCurrentProcess().MainModule.FileName;
			ProcessStartInfo startInfo = new ProcessStartInfo(exeName)
			{
				UseShellExecute = true,
				Verb = "runas" // 提升权限
			};

			try
			{
				Process.Start(startInfo);

			}
			catch (Exception ex)
			{
				throw new Exception("错误！无法使用管理权限打开应用");
			}
		}
	}
}
