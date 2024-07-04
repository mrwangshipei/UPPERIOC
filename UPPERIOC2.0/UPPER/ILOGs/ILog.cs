using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.enums;

namespace UPPERIOC.UPPER.ILOG
{
	public interface ILog
	{
		/// <summary>
		/// 输出日志
		/// </summary>
		/// <param name="LogType">可以是Warn一类的类型，也可以是Color.ToString()...</param>
		/// <param name="Msg">消息文本</param>
		 void Log(LogType LogType, string Msg);
	}
}
