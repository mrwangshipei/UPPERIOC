using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPPERIOC2.UPPER.EmailErrorSender.Sender;
using UPPERIOC2.UPPER.Util;

namespace FrmControl.C
{
	public class SystemStopwatch: UserControl
	{
		TempForm te = new TempForm();
		CancellationToken can = new CancellationToken();
		private int mainThreadId;
		private Thread mainThread;

		public SystemStopwatch() {
			/*BackgroundImage = Properties.Resources.实验室监控;
			BackgroundImageLayout = ImageLayout.Stretch;
			te.MouseLeave += MouseleaveD;
			this.MouseEnter += MouseEnterD;*/
			this.Visible = false;
		//	mainThread = Thread.CurrentThread;
			mainThreadId = Thread.CurrentThread.ManagedThreadId;
			Task.Factory.StartNew(() => {
				while (this.FindForm()!= null && !this.FindForm().Visible)
				{
					Thread.Sleep(20);
				}
				
				while (true)
				{
					try
					{

						StartAnewStopwatch();
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message +ex.StackTrace);
					}
					Thread.Sleep(30);
				}
			},can);
		}
		
		private void StartAnewStopwatch()
		{
			MyStopwatch sw = MyStopwatch.StartNew();
			Thread.Sleep(300);

			var ta = this.BeginInvoke(new Action(() =>
			{
					sw.Stop();
				}));
			ta.AsyncWaitHandle.WaitOne(10000);
			//bool r = Task.WaitAll(new Task[] { ta },10000);
				sw.Dispose();
			if (sw.GetAdd() > 9000 )
			{
				var re = PrintStackTrace(Process.GetCurrentProcess().Id);
				re = "应用不正常响应,堆栈信息在" + re;
				if (EmailSender.instance == null)
				{
					Show("错误邮件未配置。堆栈死机。"+re,"提示");
				}
				EmailSender.instance?.SendEmail(re);
			}
			else
			{

			}

		}
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
		private const uint SWP_NOMOVE = 0x0002;
		private const uint SWP_NOSIZE = 0x0001;
		private const uint SWP_SHOWWINDOW = 0x0040;

		public static DialogResult Show(string message, string title)
		{
			DialogResult result = MessageBox.Show(message, title);

			// 获取 MessageBox 窗口句柄
			IntPtr hWnd = FindWindow(null, title);
			if (hWnd != IntPtr.Zero)
			{
				SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
			}

			return result;
		}
		public string PrintStackTrace(int processId)
		{
			return null;
           /* DataTarget target = DataTarget.AttachToProcess(processId, 3000, AttachFlag.Passive);
			System.Threading.Thread.Sleep(3000); // 等待数据收集

			ClrRuntime runtime = target.ClrVersions[0].CreateRuntime();

			foreach (var thread in runtime.Threads)
			{
				if (thread.ManagedThreadId != mainThreadId) continue;

				Console.WriteLine($"Thread {thread.ManagedThreadId:X}:");
				var str = "";

				foreach (var frame in thread.StackTrace)
				{
					str += ($"{frame}");
				}
				return str;
			}
			return "";*/
		}
		protected override void DestroyHandle()
		{
			base.DestroyHandle();
			can.ThrowIfCancellationRequested();
		}
		private void MouseleaveD(object sender, EventArgs e)
		{
			te.Visible = false ;
		}

		private void MouseEnterD(object sender, EventArgs e)
		{
			te.Visible = true;

		}
	}

	
}
