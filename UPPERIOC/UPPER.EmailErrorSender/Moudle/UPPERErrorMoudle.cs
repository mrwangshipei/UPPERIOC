using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC2.UPPER.EmailErrorSender.Sender;

namespace UPPERIOC2.UPPER.EmailErrorSender.Moudle
{
    public class UPPERErrorMoudle : IUPPERMoudle
	{
		public Type[] DependisMoudel { get => new Type[] { }; set => throw new NotImplementedException(); }

        private int mainThreadId = 0;
		public void AfterCreateInstance(IContainerProvider containerProvider)
		{
		}

		public void InitEnd(IContainerProvider containerProvider)
		{

			AppDomain.CurrentDomain.UnhandledException += ExHandle; ;
			mainThreadId = Thread.CurrentThread.ManagedThreadId;
			
			Application.ThreadException += ExHandle;
		}

		private void ExHandle(object sender, UnhandledExceptionEventArgs e)
		{
			EmailSender.instance.SendEmail(e.ExceptionObject as Exception);
		}

		private void ExHandle(object sender, ThreadExceptionEventArgs e)
		{
			EmailSender.instance.SendEmail(e.Exception);
		}

		public void IniterAndLoadClass(IContainerProvider containerProvider)
		{
		}

		public void PreIniter(IContainerProvider containerProvider)
		{
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

			EmailSender em = new EmailSender(containerProvider);
			EmailSender.instance = em;
		}
	}
}
