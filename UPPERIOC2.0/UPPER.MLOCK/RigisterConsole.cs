using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using UPPERIOC.UPPER.IOC.Moudle;
using UPPERIOC2.UPPER.MLOCK.IConfiguation;
using static UPPERIOC.UPPER.IOC.Moudle.UPPERMLockMoudle;

namespace UPPERIOC2.UPPER.MLOCK
{
	public	 class RigisterConsole
	{


		public static bool CompareSecureStrings(SecureString secureString, string plainString)
		{
			// Convert SecureString to plain string
			IntPtr secureStringPtr = IntPtr.Zero;
			try
			{
				secureStringPtr = SecureStringMarshal.SecureStringToGlobalAllocUnicode(secureString);
				string secureStringPlain = Marshal.PtrToStringUni(secureStringPtr);

				// Compare the two strings
				return secureStringPlain.Equals(plainString);
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
	

	public static  void Rigister(MLockConfiguation m) {
			Console.WriteLine("欢迎使用注册器，请输入需要注册的验证码");
			// 使用SecureString来存储密码，避免在内存中留下明文密码  
			SecureString password = new SecureString();

			// 读取用户输入直到回车  
			while (true)
			{
				ConsoleKeyInfo key = Console.ReadKey(true); // 第二个参数true表示不将按键显示在控制台上  

				if (key.Key == ConsoleKey.Enter)
				{
					break; // 如果按下的是回车键，则退出循环  
				}
				else if (key.Key == ConsoleKey.Backspace)
				{
					// 如果按下的是退格键，并且SecureString中有字符，则移除最后一个字符  
					if (password.Length > 0)
					{
						password.RemoveAt(password.Length - 1);
						Console.Write("\b \b"); // 使用退格和空格覆盖之前的字符，然后再次退格  
					}
				}
				else if (key.KeyChar >= 32) // 忽略控制字符  
				{
					// 将输入的字符添加到SecureString中  
					password.AppendChar(key.KeyChar);
					// 这里不打印任何字符，因为我们要隐藏输入  
				}
			};
			
			if (!CompareSecureStrings(password,"admin"))
			{
				Console.WriteLine("注册失败，密码错误");
				return;
			}
			var r = HashHelper.EncryptWithSalt(m.Solt);
			var path = Path.Combine(Environment.CurrentDirectory, m.Listenaddr);
			File.Delete(path);
			File.WriteAllText(path,r,Encoding.ASCII);

			Console.WriteLine("注册成功，使用愉快");
			 Console.ReadLine();

		}
		public static bool ValidateSecureString(SecureString secureString)
		{
			// 确保传入的是SecureString类型
			if (secureString == null)
				throw new ArgumentException("secureString");

			// 将SecureString转换为常规字符串进行验证
			IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(secureString);
			try
			{
				return ptr != IntPtr.Zero && System.Runtime.InteropServices.Marshal.ReadInt32(ptr) != 0;
			}
			finally
			{
				// 释放非托管资源
				System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
			}
		}

	}
}
