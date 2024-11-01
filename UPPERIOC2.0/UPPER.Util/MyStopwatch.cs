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
		private bool Run = true;
		private bool start = false;
		protected volatile int ElapsedMilliseconds = 0;
		private CancellationToken can = new CancellationToken();
		public int GetAdd(int value = 0) {
			lock (this)
			{
				return ElapsedMilliseconds += value;
			}
		}
		public MyStopwatch() {
			Task.Factory.StartNew(() => {
				while (Run)
				{
					DateTime st = DateTime.Now;
					while (start)
					{
						//st = ;
						st = DateTime.Now;

						Thread.Sleep(500);
						if ((DateTime.Now - st).TotalMilliseconds < 600)
						{
							GetAdd(501);
						}
						Console.WriteLine((DateTime.Now - st).TotalMilliseconds);
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
			can.ThrowIfCancellationRequested();
		}
		public static MyStopwatch StartNew()
		{
			var r = new MyStopwatch();
			r.Start();
			return r;
		}

		public void Dispose()
		{
			Run = false;

		}
	}
}
