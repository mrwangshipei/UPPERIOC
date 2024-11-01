using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Windows.Forms;

namespace UpperComAutoTest.MyControls
{

	public class AsyncTimer : IDisposable
	{
		public int dueTime = 10;
		public int period = 10;
		public CancellationTokenSource cancellationTokenSource;
		public Action callback = ()=> { };
		private bool run = true;
		private bool enable = false;
		private readonly object enableLock = new object();

		public bool Enable
		{
			get
			{
				lock (enableLock)
				{
					return enable;
				}
			}
			set
			{
				lock (enableLock)
				{
					enable = value;
				}
			}
		}

		public AsyncTimer(){
			Run();
		}
		public AsyncTimer(Action callback, int dueTime, int period)
		{
			this.callback = callback;
			this.dueTime = dueTime;
			this.period = period;
			Run();
		}

		public void Dispose()
		{
			run = false;
		}

		public void Run() {
			Task.Run(async () =>
			{
			//	cancellationTokenSource = new CancellationTokenSource();

				while (run)
				{


					if (dueTime > 0)
					{
						await Task.Delay(dueTime);
					}
				
					while (Enable)
					{
						callback();
						if (period > 0)
						{
							await Task.Delay(period);
						}
					}
					Enable = false;
				}
			});
		}
		public void Start()
		{
			if (Enable)
			{
				return;
			}
			Enable = true;
		
		}

		public void Stop()
		{
			Enable = false;

		}
	}

}
