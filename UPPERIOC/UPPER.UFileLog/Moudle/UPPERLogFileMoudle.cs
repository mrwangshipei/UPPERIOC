using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.UFileLog.IConfiguation;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.IOC.Moudle;
using UPPERIOC.UPPER.UFileLog.DefineLog;
using UPPERIOC.UPPER.IOC.Center.Interface;
using System.Windows.Forms;

namespace UPPERIOC.UPPER.UFILELOG.Moudle
{
    public class UPPERLogFileMoudle : IUPPERMoudle
	{
        IContainerProvider? containerProvider;
        public Type[]? DependisMoudel { get; set; } = new Type[] { } ;

        public override void AfterCreateInstance(IContainerProvider containerProvider)
		{
			var con = (IFileLogConfiguation)containerProvider.GetInstance(typeof(IFileLogConfiguation));
			LogCenter.AddILog(containerProvider.Rigister<FileLog>());
            BindExceptionHandler();

        }

        public override void PreIniter(IContainerProvider containerProvider)
		{

		}

        public override void InitEnd(IContainerProvider containerProvider)
		{

		}
        private static void BindExceptionHandler()
        {
            //设置应用程序处理异常方式：ThreadException处理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理未捕获的异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                HandleEx(ex);
            }
            else
            {
                LogCenter.Log(UPPERIOC.UPPER.enums.LogType.Error, $"全局异常：{e.ExceptionObject.ToString()}\r\n");

            }

        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleEx(e.Exception);
        }
        private static void HandleEx(Exception ex)
        {
            LogCenter.Log(UPPERIOC.UPPER.enums.LogType.Error, $"全局异常：{ex.Message}\r\n{ex.StackTrace}");
            throw ex;
        }


        public override void IniterAndLoadClass(IContainerProvider containerProvider)
		{
			this.containerProvider = containerProvider;

		}
	}
}
