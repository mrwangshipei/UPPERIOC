using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.enums;

namespace UPPERIOC.UPPER.UFileLog.IConfiguation
{
	public interface IFileLogConfiguation
	{
		/// <summary>
		/// 目录文件名称
		/// </summary>
         string DirectoryName { get; set; }
		/// <summary>
		/// 默认的后缀名
		/// </summary>
		 string DefaultExt{ get; set; }

		/// <summary>
		/// 什么级别的日志可以被打印
		/// </summary>
		 List<LogType> WhichTypePrint{ get; set; }

		/// <summary>
		/// 日志名称Format
		/// </summary>
         string FileNameTimeFormat { get; set; }
		/// <summary>
		/// 日志保存多少小时
		/// </summary>		
		 int HowManyHourSave { get; set; }
    }
}
