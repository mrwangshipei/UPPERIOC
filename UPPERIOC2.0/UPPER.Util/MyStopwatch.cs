using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UPPERIOC2.UPPER.Util
{
	public class MyStopwatch : IDisposable
	{
		private bool start = false;
		public long ElapsedMilliseconds = 0;
		private CancellationToken can = new CancellationToken();
		public MyStopwatch() {
			Task.Factory.StartNew(() => {
				while (true)
				{
					DateTime st = DateTime.Now;
					while (start)
					{
						//st = ;
						Thread.Sleep(50);
						if ((DateTime.Now - st).TotalMilliseconds < 60)
						{
							ElapsedMilliseconds +=(long) (DateTime.Now - st).TotalMilliseconds;
							st = DateTime.Now;
						}
					}
					Thread.Yield();
				}
			},can);
		}
		public void Start() {
			start = true;
		}
		public void Stop()
		{
			start = false;
		}
		public static MyStopwatch StartNew()
		{
			var r = new MyStopwatch();
			r.Start();
			return r;
		}

		public void Dispose()
		{
			can.ThrowIfCancellationRequested();
		}
	}
}
