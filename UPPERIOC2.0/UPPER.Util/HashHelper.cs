using System;
using System.Collections.Generic;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace UPPERIOC2.UPPER.Util
{
	public class HashHelper
	{
		public static string EncryptWithSalt(string salt,string machineCode = "")
		{
			if (string.IsNullOrWhiteSpace(machineCode))
			{
				machineCode = GenerateMachineId();

			}
			using (var sha256 = SHA256.Create())
			{
				var saltedMachineCode = Encoding.UTF8.GetBytes($"{machineCode}{salt}");
				var hash = sha256.ComputeHash(saltedMachineCode);

				// 将哈希值转换为十六进制字符串  
				var hashString = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();

				return hashString;
			}
		}
		internal static bool VerifyWithSalt(string salt, string storedHash)
		{
			//string machineCode = GenerateMachineId();

			var computedHash = EncryptWithSalt(salt);
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
