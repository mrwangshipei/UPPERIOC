using System;
using System.Runtime.InteropServices;
namespace UPPERIOC.Util
{ 
	public class TaskbarHider
	{
		// Windows API函数声明
		[DllImport("coredll.dll", SetLastError = true)]
		public static extern int FindWindow(string lpClassName, string lpWindowName);

		[DllImport("coredll.dll", SetLastError = true)]
		public static extern int ShowWindow(int hWnd, int nCmdShow);

		private const int SW_HIDE = 0;
		private const int SW_RESTORE = 9;
		private const int SW_SHOW = 5;
		private const int SW_SHOWNA = 8;

		public static void HideTaskbar()
		{
			int hWnd = FindWindow("HHTaskBar", null);
			ShowWindow(hWnd, SW_HIDE);
		}

		public static void ShowTaskbar()
		{
			int hWnd = FindWindow("HHTaskBar", null);
			ShowWindow(hWnd, SW_SHOW);
		}
	}
}