using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UPPERIOC2.UPPER.Util
{
    public class RegisterHelper
    {
        // 读取注册表值  
        public static string GetLockFile(string keyName, string valueName)
        {

                // 打开注册表键  
            //  using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName))
            {
                // 如果键存在并且值存在，则返回该值  
               // i//f (key != null)
                {
                 //   object o = key.GetValue(valueName);
                 ///   if (o != null)
                    {
                   //     return o.ToString();
                    }
                }
            }
            // 如果没有找到，返回null  
            FileInfo f = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, keyName, valueName));
            if (!f.Exists)
            {
                return null;
            }
            return File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory ,keyName,valueName));
        }

        // 写入注册表值  
        public static void SaveLockFile(string keyName, string valueName, object value)
        {
            // 打开或创建注册表键  
         //   using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyName))
            {
                // 设置值  
               // key.SetValue(valueName, value);
            }
			DirectoryInfo f = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, keyName));
            if (!f.Exists)
            {
                f.Create();
            }
			FileInfo fI = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, keyName, valueName));
            File.WriteAllText(fI.FullName,value.ToString(),Encoding.ASCII);
            

		}
	}
}
