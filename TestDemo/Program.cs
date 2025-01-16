
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestDemo
{
	internal class Program
	{
		private static int j;
		private static int rowLength;

		static void Main(string[] args)
		{

			while (true)
			{
				Console.Write("请输入要测试次数");
				if (int.TryParse(Console.ReadLine().Trim(), out int count))
				{
					var x = new double[count];
					var y = new double[count];
					var sw = Stopwatch.StartNew();
					for (int i = 0; i < count; i++)
					{
						x[i] = (i * rowLength + j * 2 + 1 * Math.Sin(i * rowLength + j * 2 + 2 / 180 * Math.PI)); ;
					}
					sw.Stop();
					Console.WriteLine("使用基本for消耗时间" + sw.ElapsedMilliseconds);
					sw = Stopwatch.StartNew();

					sw.Stop();
					Console.WriteLine("使用线程池消耗时间" + sw.ElapsedMilliseconds);
					bool all = true;
					for (int i = 0; i < x.Length; i++)
					{
						if (x[i] != y[i])
						{
							all = false;
							Console.WriteLine("结果不一样哦");
						}
					}
					if (all)
					{
						Console.WriteLine("结果一样");
					}
				}

			
			}
		}
	}
}
