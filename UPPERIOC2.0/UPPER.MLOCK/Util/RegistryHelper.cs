using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace UPPERIOC2.UPPER.MLOCK.Util
{
	public class RegistryHelper
	{
		// 读取注册表值  
		public static string ReadRegistry(string keyName, string valueName)
		{
			// 打开注册表键  
			using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName))
			{
				// 如果键存在并且值存在，则返回该值  
				if (key != null)
				{
					Object o = key.GetValue(valueName);
					if (o != null)
					{
						return o.ToString();
					}
				}
			}
			// 如果没有找到，返回null  
			return null;
		}

		// 写入注册表值  
		public static void WriteRegistry(string keyName, string valueName, object value)
		{
			// 打开或创建注册表键  
			using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyName))
			{
				// 设置值  
				key.SetValue(valueName, value);
			}
		}
	}
}
