using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using static System.Net.Mime.MediaTypeNames;

namespace UPPERIOC2.UPPER.Util.Moudle
{
	[StructLayout(LayoutKind.Sequential)]
	struct TOKEN_ELEVATION_TYPE
	{
		public int TokenElevationType;
	}

	public class MustRunAsAdminMoudle : IUPPERMoudle
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

		// P/Invoke declarations  
		[DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern bool OpenProcessToken(IntPtr ProcessHandle, int DesiredAccess, out IntPtr TokenHandle);

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseHandle(IntPtr hObject);

		[DllImport("shell32.dll", SetLastError = true)]
		public static extern IntPtr ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SHELLEXECUTEINFO
		{
			public int cbSize;
			public uint fMask;
			public IntPtr hwnd;
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpVerb;
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpFile;
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpParameters;
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpDirectory;
			public int nShow;
			public IntPtr hInstApp;
			public IntPtr lpIDList;
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpClass;
			public IntPtr hkeyClass;
			public uint dwHotKey;
			public IntPtr hIcon;
			public IntPtr hProcess;
		}

		// Constants  
		private const int TOKEN_QUERY = 0x0008;
		private const int TOKEN_ELEVATION_TYPE = 20;

	
		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool GetTokenInformation(IntPtr TokenHandle, int TokenInformationClass, IntPtr TokenInformation, int TokenInformationLength, out int ReturnLength);
		// 检查当前进程是否以管理员身份运行  
		private static bool IsRunAsAdmin()
		{
			using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
			{
				WindowsPrincipal principal = new WindowsPrincipal(identity);
				return principal.IsInRole(WindowsBuiltInRole.Administrator);
			}
		}

		// 以管理员身份重新启动应用程序  
		private static void RunAsAdmin()
		{
			ProcessStartInfo processInfo = new ProcessStartInfo();
			processInfo.UseShellExecute = true;
			processInfo.FileName = Process.GetCurrentProcess().MainModule.FileName;
			processInfo.Verb = "runas"; // 以管理员身份运行  

			try
			{
				Process.Start(processInfo);
			}
			catch (Exception ex)
			{
				MessageBox.Show("无法以管理员身份启动应用程序: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			// 关闭当前应用程序  
			Process.GetCurrentProcess().Kill();
			Thread.Sleep(3000);
		}
		/*	public static bool IsRunAsAdmin()
			{
				IntPtr currentProcess = Process.GetCurrentProcess().Handle;
				IntPtr tokenHandle;

				// Get a handle to the access token for the current process.  
				if (!OpenProcessToken(currentProcess, TOKEN_QUERY, out tokenHandle))
				{
					return false;
				}

				int returnLength = 0;
				IntPtr tokenInfo = IntPtr.Zero;

				try
				{
					// Allocate correctly-sized memory to receive the token information.  
					if (GetTokenInformation(tokenHandle, TOKEN_ELEVATION_TYPE, IntPtr.Zero, 0, out returnLength))
					{
						// The call should have failed with ERROR_INSUFFICIENT_BUFFER  
						throw new InvalidOperationException("Unexpected success.");
					}

					if (Marshal.GetLastWin32Error() != 122 *//* ERROR_INSUFFICIENT_BUFFER *//*)
					{
						return false;
					}

					tokenInfo = Marshal.AllocHGlobal(returnLength);

					// Now get the token information.  
					if (!GetTokenInformation(tokenHandle, TOKEN_ELEVATION_TYPE, tokenInfo, returnLength, out returnLength))
					{
						return false;
					}

					TOKEN_ELEVATION_TYPE elevationType = (TOKEN_ELEVATION_TYPE)Marshal.PtrToStructure(tokenInfo, typeof(TOKEN_ELEVATION_TYPE));

					// TokenElevationTypeTokenIsElevated is not zero if the process is elevated.  
					return elevationType.TokenElevationType == 2;
				}
				finally
				{
					// Free the resources.  
					if (tokenInfo != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(tokenInfo);
					}
					CloseHandle(tokenHandle);
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
			}*/
	}
}
