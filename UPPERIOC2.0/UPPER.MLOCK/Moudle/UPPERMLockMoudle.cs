using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.ILOG;
using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using UPPERIOC.UPPER.IOC.Extend;
using UPPERIOC2.UPPER.MLOCK.IConfiguation;

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
		public void AfterCreateInstance(IContainerProvider containerProvider)
		{
			var c = containerProvider.GetAllInstance<MLockConfiguation>();
			if (c.Length <= 0)
			{
				throw new Exception("至少注册一个MLockConfiguation的对象");
			}
			m = c[0];
			var lisaddr = Path.Combine(Environment.CurrentDirectory, m.Listenaddr);
			if (!File.Exists(lisaddr))
			{
				m.Noregister();

			}
			if (HashHelper.VerifyWithSalt(m.Solt ,File.ReadAllText(lisaddr)))
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

		public void PreIniter(IContainerProvider containerProvider)
		{
			//this.containerProvider = containerProvider;
			//	LoadClass();
		}

		public void InitEnd(IContainerProvider containerProvider)
		{

		}
		IContainerProvider containerProvider;
		public void IniterAndLoadClass(IContainerProvider containerProvider)
		{

		}


		public class HashHelper
		{
			public static string EncryptWithSalt( string salt)
			{
				string machineCode = GenerateMachineId();
				using (var sha256 = SHA256.Create())
				{
					var saltedMachineCode = Encoding.UTF8.GetBytes($"{machineCode}{salt}");
					var hash = sha256.ComputeHash(saltedMachineCode);

					// 将哈希值转换为十六进制字符串  
					var hashString = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();

					return hashString;
				}
			}
			internal static bool VerifyWithSalt( string salt, string storedHash)
			{
				//string machineCode = GenerateMachineId();

				var computedHash = EncryptWithSalt( salt);
				return computedHash == storedHash;
			}
			 static string GenerateMachineId()
			{
				// 获取多个系统属性以生成唯一标识符  
				string cpuId = GetCpuId();
				string biosId = GetBiosId();
				string baseBoardId = GetBaseBoardId();

				// 将所有属性合并成一个字符串  
				string combinedId = $"{cpuId}{biosId}{baseBoardId}";

				// 使用SHA256哈希算法对合并后的字符串进行哈希处理  
				using (SHA256 sha256Hash = SHA256.Create())
				{
					byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(combinedId));

					// 将哈希值转换为十六进制字符串  
					StringBuilder sBuilder = new StringBuilder();

					for (int i = 0; i < data.Length; i++)
					{
						sBuilder.Append(data[i].ToString("x2"));
					}

					return sBuilder.ToString();
				}
			}

			private static string GetCpuId()
			{
				string cpuInfo = string.Empty;

				ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

				foreach (ManagementObject mo in searcher.Get())
				{
					cpuInfo = (string)mo["ProcessorId"];
					break; // 通常只需要第一个CPU的ID  
				}

				return cpuInfo;
			}

			private static string GetBiosId()
			{
				string biosId = string.Empty;

				ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");

				foreach (ManagementObject mo in searcher.Get())
				{
					biosId = (string)mo["SerialNumber"];
					if (!string.IsNullOrEmpty(biosId)) break; // 如果SerialNumber为空，则尝试其他属性  
					biosId = (string)mo["SMBIOSBIOSVersion"];
					break;
				}

				return biosId;
			}

			private static string GetBaseBoardId()
			{
				string baseBoardId = string.Empty;

				ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");

				foreach (ManagementObject mo in searcher.Get())
				{
					baseBoardId = (string)mo["SerialNumber"];
					if (!string.IsNullOrEmpty(baseBoardId)) break; // 如果SerialNumber为空，则可能没有其他合适的属性  
				}

				return baseBoardId;
			}
		}
	}

}
