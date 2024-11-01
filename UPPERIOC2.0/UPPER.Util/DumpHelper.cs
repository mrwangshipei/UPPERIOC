using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

public class DumpHelper
{
	[DllImport("DbgHelp.dll", SetLastError = true)]
	static extern bool MiniDumpWriteDump(
		IntPtr hProcess,
		uint processId,
		IntPtr hFile,
		MINIDUMP_TYPE dumpType,
		IntPtr expParam,
		IntPtr userStreamParam,
		IntPtr callbackParam);

	[Flags]

	enum MINIDUMP_TYPE : uint
	{
		MiniDumpNormal = 0x00000000, // 标准小型转储，仅包含必要的系统信息和堆栈  
		MiniDumpWithDataSegs = 0x00000001, // 包含数据段的信息  
		MiniDumpWithFullMemory = 0x00000002, // 包含进程的所有内存（可能会导致非常大的转储文件）  
		MiniDumpWithHandleData = 0x00000004, // 包含句柄信息  
		MiniDumpWithUnloadedModules = 0x00000008, // 包含已卸载模块的信息  
		MiniDumpWithIndirectlyReferencedMemory = 0x00000010, // 包含间接引用的内存  
															 // ... 其他标志，如 MiniDumpWithFilterData, MiniDumpWithPrivateReadWriteMemory 等  
	}

	public static void CreateDump(string dumpFilePath)
	{
		Process currentProcess = Process.GetCurrentProcess();
		using (FileStream fs = new FileStream(dumpFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
		{
			bool result = MiniDumpWriteDump(
				currentProcess.Handle,
				(uint)currentProcess.Id,
				fs.SafeFileHandle.DangerousGetHandle(),
				MINIDUMP_TYPE.MiniDumpNormal,
				IntPtr.Zero,
				IntPtr.Zero,
				IntPtr.Zero);

			if (!result)
			{
				throw new Exception("Failed to create dump file.");
			}
		}
	}
}