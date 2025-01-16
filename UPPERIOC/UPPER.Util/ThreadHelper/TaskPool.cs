using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UPPERIOC2.UPPER.Util.ThreadHelper
{
	public class TaskPool:IDisposable
	{
		public TaskPool Instance { get; set; } = new TaskPool(8);
        public int Count { get; set; }

        public TaskPool(int count) {
			Count = count;
		}
		protected void Notify() {
			
		}
		/// <summary>
		/// 执行一段Act，Count次数，注意执行的顺序是无序的，
		/// </summary>
		/// <param name="Count"></param>
		/// <param name="Act"></param>
		public void BeginDo(int Count,Action<int> Act)
		{
			
			var re = Parallel.For(0, Count, Act);
			while (re.IsCompleted)
			{
				Thread.Sleep(0);
				Thread.Sleep(0);
			}
			
		}

		public void Dispose()
		{
		}
	}

}
