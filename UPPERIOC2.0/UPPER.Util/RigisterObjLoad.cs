using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace UPPERIOC2.UPPER.Util
{
	public class RigisterObjLoad
	{
		public static RigisterObjLoad GetInstance(string root) {
			RigisterObjLoad r = new RigisterObjLoad();
			r.RegistryRoot = root;
			return r;
		}
		private  string RegistryRoot ;

		public  void SaveObjectToRegistry(string keyName, object obj)
		{
			using (RegistryKey baseKey = Registry.CurrentUser.CreateSubKey(RegistryRoot))
			{
				using (RegistryKey key = baseKey.CreateSubKey(keyName))
				{
					foreach (var prop in obj.GetType().GetProperties())
					{
						if (prop.CanRead)
						{
							var value = prop.GetValue(obj, null);
							key.SetValue(prop.Name, value.ToString(), RegistryValueKind.String);
						}
					}
				}
			}
		}

		public  T LoadObjectFromRegistry<T>(string keyName) where T : new()
		{
			T obj = new T();
			using (RegistryKey baseKey = Registry.CurrentUser.OpenSubKey(RegistryRoot))
			{
				if (baseKey != null)
				{
					using (RegistryKey key = baseKey.OpenSubKey(keyName))
					{
						if (key != null)
						{
							foreach (var propName in key.GetValueNames())
							{
								var prop = obj.GetType().GetProperty(propName);
								if (prop != null && prop.CanWrite)
								{
									// 注意：这里我们简单地尝试将所有值作为字符串读取并转换为属性类型，这可能需要更复杂的处理  
									var value = key.GetValue(propName).ToString();
									try
									{
										if (prop.PropertyType == typeof(int))
										{
											prop.SetValue(obj, Convert.ToInt32(value), null);
										}
										else if (prop.PropertyType == typeof(string))
										{
											prop.SetValue(obj, value, null);
										}
										// 可以根据需要添加更多类型处理  
									}
									catch (Exception ex)
									{
										Console.WriteLine($"Error setting property {propName}: {ex.Message}");
									}
								}
							}
						}
					}
				}
			}
			return obj;
		}
	}
}
