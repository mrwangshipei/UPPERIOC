using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using UPPERIOC.UPPER.IOC.Moudle;
using UPPERIOC2.UPPER.MLOCK.IConfiguation;
using UPPERIOC2.UPPER.Util;
using static UPPERIOC.UPPER.IOC.Moudle.UPPERMLockModule;

namespace UPPERIOC2.UPPER.MLOCK.Center
{
    public class RegistryRegisterConsole
    {


	
		internal static bool CompareSecureStrings(SecureString secureString, string plainString)
		{
			// Convert SecureString to plain string
			IntPtr secureStringPtr = IntPtr.Zero;
			try
			{
				var s = new SecureString();
				for (int i = 0; i < plainString.Length; i++)
				{
					s.AppendChar(plainString[i]);

				}

				return s.Equals(secureString);
			
			}
			finally
			{
				// Ensure the secure string memory is cleared
				if (secureStringPtr != IntPtr.Zero)
				{
					Marshal.ZeroFreeGlobalAllocUnicode(secureStringPtr);
				}
			}
		}
		internal static void Rigister(MLockConfiguation m)
        {
           
            var r = HashHelper.EncryptWithSalt(m.Solt);
            RegisterHelper.Instance.SaveLockFile(m.Listenaddr, m.LockName,r);

			Console.WriteLine("注册成功，使用愉快");
        
        }
        internal static bool ValidateSecureString(SecureString secureString)
        {
            // 确保传入的是SecureString类型
            if (secureString == null)
                throw new ArgumentException("secureString");

            // 将SecureString转换为常规字符串进行验证
            IntPtr ptr = Marshal.SecureStringToBSTR(secureString);
            try
            {
                return ptr != IntPtr.Zero && Marshal.ReadInt32(ptr) != 0;
            }
            finally
            {
                // 释放非托管资源
                Marshal.ZeroFreeBSTR(ptr);
            }
        }

    }
}
