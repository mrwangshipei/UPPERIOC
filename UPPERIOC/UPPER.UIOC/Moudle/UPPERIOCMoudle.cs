using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.ILOG;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;

namespace UPPERIOC.UPPER.IOC.Moudle
{
	public class UPPERIOCMoudle : IUPPERMoudle
	{
		private void LoadClass()
		{
			// 获取当前执行的程序集  
			Assembly executingAssembly = Assembly.GetEntryAssembly();
			foreach (var item in executingAssembly.GetTypes())
			{
				var item1 = Assembly.GetAssembly(item);
				if (HasBaseClassWithAttribute<IOCObject>(item))
				{
					//Contain[item] = null;
					containerProvider.Rigister(item);
				}
			}
			// 获取该程序集所依赖的所有程序集的名字  
			AssemblyName[] referencedAssemblies = executingAssembly.GetReferencedAssemblies();

			foreach (AssemblyName assemblyName in referencedAssemblies)
			{
				if (assemblyName.FullName == Assembly.GetExecutingAssembly().GetName().FullName)
				{
					
					continue;
				}
				try
				{
					// 尝试加载依赖的程序集  
					Assembly asm = Assembly.Load(assemblyName);
					foreach (var item in asm.GetTypes())
					{
						var item1 = Assembly.GetAssembly(item);
						if (HasBaseClassWithAttribute<IOCObject>(item))
						{
							//	Contain[item] = null;
							containerProvider.Rigister(item);

						}
					}
					// 输出加载的程序集的信息  
					Console.WriteLine("Loaded assembly: " + asm.FullName);

					// 现在你可以通过 loadedAssembly 变量来探索这个程序集中的类型和方法了  
				}
				catch (Exception ex)
				{
					// 如果加载失败，打印异常信息  
					Console.WriteLine("Failed to load assembly: " + assemblyName.FullName + ". Error: " + ex.Message);
				}
			}

		}

		public bool HasBaseClassWithAttribute<TAttribute>(Type type) where TAttribute : Attribute
		{
			while (type != null && type != typeof(object))
			{
				if (type.GetCustomAttribute<TAttribute>() != null)
				{
					return true;
				}
				type = type.BaseType; // 移动到继承链中的下一个基类  
			}
			return false;
		}

		public void AfterCreateInstance(IContainerProvider containerProvider)
		{

		}

		public void PreIniter(IContainerProvider containerProvider)
		{

		}

		public void InitEnd(IContainerProvider containerProvider)
		{
			LoadLog();

		}
		IContainerProvider containerProvider;
		public void IniterAndLoadClass(IContainerProvider containerProvider)
		{
			this.containerProvider = containerProvider;
			LoadClass();
		}

		private void LoadLog()
		{
			object[] ilog = null;
			ilog = containerProvider.GetAllInstance(typeof(ILog));
			if ((ilog)!= null  && ilog.Length > 0)
			{
				LogCenter.AddAllLog(ilog.Select(i => (ILog)i).ToArray());

			}
		}
	}
}
