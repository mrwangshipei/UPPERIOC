using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.enums;
using UPPERIOC.UPPER.ILOG;

namespace UPPERIOC.UPPER
{
	public class LogCenter
	{
		internal static List<ILog> logs = new List<ILog>();
		internal static void AddILog(ILog log) 
		{
			logs.Add(log);
		}

		public static void Log(LogType type,string msg) 
		{
			logs.ForEach(item => item.Log(type,msg));
		}

	

		internal static void AddAllLog(ILog[] ls)
		{
			logs.AddRange(ls);
		}
	}
}
