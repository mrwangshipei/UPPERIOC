namespace UPPERIOC2.UPPER.Util
{
    public class RegisterHelper
    {
        public static RegisterHelper Instance = new RegisterHelper();

        /// <summary>
        /// 允许用户将自定义实现替换默认的注册表/文件操作逻辑。
        /// </summary>
        public static void SetRegisterWriter(RegisterHelper instanc)
        {
            Instance = instanc;
        }

        // 读取注册表值或文件值
        public virtual string GetLockFile(string keyName, string valueName)
        {
#if NET462
            // 在 .NET Framework 4.6.2 下使用注册表
            return ReadFromRegistry(keyName, valueName);
#else
            // 在 .NET Standard 2.0 下，根据平台判断使用注册表或文件存储
            if (IsWindows() && SupportsRegistry())
            {
                return ReadFromRegistry(keyName, valueName);
            }
            else
            {
                return ReadFromFile(keyName, valueName);
            }
#endif
        }

        // 写入注册表值或文件值
        public virtual void SaveLockFile(string keyName, string valueName, object value)
        {
#if NET462
            // 在 .NET Framework 4.6.2 下使用注册表
            WriteToRegistry(keyName, valueName, value);
#else
            // 在 .NET Standard 2.0 下，根据平台判断使用注册表或文件存储
            if (IsWindows() && SupportsRegistry())
            {
                WriteToRegistry(keyName, valueName, value);
            }
            else
            {
                WriteToFile(keyName, valueName, value);
            }
#endif
        }

        private string ReadFromRegistry(string keyName, string valueName)
        {
#if NET462 || (NETSTANDARD && WINDOWS && INCLUDE_REGISTRY)
          
#endif
            using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyName))
            {
                if (key != null)
                {
                    var value = key.GetValue(valueName);
                    if (value != null)
                    {
                        return value.ToString();
                    }
                }
            }
            return null;
        }

        private void WriteToRegistry(string keyName, string valueName, object value)
        {

            using (var key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(keyName))
            {
                key.SetValue(valueName, value);
            }
        }

#if !NET462
        private string ReadFromFile(string keyName, string valueName)
        {
            string filePath = GetFilePath(keyName, valueName);
            if (System.IO.File.Exists(filePath))
            {
                return System.IO.File.ReadAllText(filePath);
            }
            return null;
        }

        private void WriteToFile(string keyName, string valueName, object value)
        {
            string filePath = GetFilePath(keyName, valueName);
            string directoryPath = System.IO.Path.GetDirectoryName(filePath);
            if (!System.IO.Directory.Exists(directoryPath))
            {
                System.IO.Directory.CreateDirectory(directoryPath);
            }
            System.IO.File.WriteAllText(filePath, value.ToString());
        }

        // 获取文件路径
        private string GetFilePath(string keyName, string valueName)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return System.IO.Path.Combine(baseDirectory, keyName, $"{valueName}.txt");
        }

        // 判断是否是 Windows 平台
        private bool IsWindows()
        {
            return System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows);
        }

        // 判断是否支持注册表操作
        private bool SupportsRegistry()
        {
            return true;
        }
#endif
    }
}
