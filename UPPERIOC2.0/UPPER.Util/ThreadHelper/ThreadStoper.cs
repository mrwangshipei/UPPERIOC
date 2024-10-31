using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UPPERIOC2.UPPER.Util.ThreadHelper
{
	public class ThreadStoper
	{
		volatile static Dictionary<int, bool> Stops = new Dictionary<int, bool>();
		/// <summary>
		/// 停止线程th直到被唤醒，每个noti毫秒检测唤醒一次
		/// </summary>
		/// <param name="th"></param>
		/// <param name="noti"></param>
		public static void Stop(int th,int noti = 10) 
		{
			Stops[th] = false;
			while (!Stops[th])
			{
				Thread.Sleep(noti);
			}
		}
		public static void Start(int th)
		{
			Stops[th] = true;

		}

	}
}
