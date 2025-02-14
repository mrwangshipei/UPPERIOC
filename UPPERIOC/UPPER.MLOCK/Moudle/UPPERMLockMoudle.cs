using System;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC2.UPPER.MLOCK.IConfiguation;
using UPPERIOC2.UPPER.Util;

namespace UPPERIOC.UPPER.IOC.Moudle
{
    public class UPPERMLockMoudle : IUPPERMoudle
	{

		public Type[] DependisMoudel { get; set; } = new Type[0];
		/*private void LoadClass()
		{
			// 获取当前执行的程序集  
			Assembly executingAssembly = Assembly.GetEntryAssembly();
			foreach (var item in executingAssembly.GetTypes())
			{
				var item1 = Assembly.GetAssembly(item);
				if (item.HasBaseClassWithAttribute<IOCMvvmModel>())
				{
					//Contain[item] = null;
					
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
						if (item.HasBaseClassWithAttribute<IOCMvvmModel>())
						{
							//	Contain[item] = null;
							//containerProvider.Rigister(item);

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

*/
		public static	MLockConfiguation m;
		public override void AfterCreateInstance(IContainerProvider containerProvider)
		{
			var c = containerProvider.GetAllInstance<MLockConfiguation>();
			if (c.Length <= 0)
			{
				throw new Exception("至少注册一个MLockConfiguation的对象");
			}
			m = c[0];
		//	var lisaddr = Path.Combine(Environment.CurrentDirectory, m.Listenaddr);
			if (RegisterHelper.Instance.GetLockFile(m.Listenaddr,m.LockName) == null)
			{
				m.Noregister();

			}
			if (HashHelper.VerifyWithSalt(m.Solt , RegisterHelper.Instance.GetLockFile( m.Listenaddr, m.LockName)))
			{
				Console.Write("验证成功");
			}
			else
			{
				m.Noregister();
				//Environment.Exit(0);

			//	throw new Exception("验证失败");


			}

		}

        public override void PreIniter(IContainerProvider containerProvider)
		{
			//this.containerProvider = containerProvider;
			//	LoadClass();
		}

        public override void InitEnd(IContainerProvider containerProvider)
		{

		}
		IContainerProvider containerProvider;
        public override void IniterAndLoadClass(IContainerProvider containerProvider)
		{

		}


	
	}

}
