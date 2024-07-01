using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.enums;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.IOC.Center.Configuation;
using UPPERIOC.UPPER.Sendor.Model;
using UPPERIOC.UPPER.UFileLog.IConfiguation;

namespace UpperComAutoTest.MyConfiguation
{
	[IOCObject]
	public class FileLogConfiguation : IFileLogConfiguation
	{
		public string DirectoryName { get => "Log"; set => throw new NotImplementedException(); }
		public string DefaultExt { get => ".log"; set => throw new NotImplementedException(); }
		public List<LogType> WhichTypePrint { get => new List<LogType>() {LogType.Debug, LogType.Error, LogType.Warn, LogType.Info }; set => throw new NotImplementedException(); }
		public string FileNameTimeFormat { get => "测试日志yyyyMMdd"; set => throw new NotImplementedException(); }
		public int HowManyHourSave { get => 48; set => throw new NotImplementedException(); }
	}
}
