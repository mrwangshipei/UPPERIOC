using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UPPERIOC2.UPPER.Util
{
	public class FileUtil
	{

		public static string FileInfoToRelativePath(FileInfo fileInfo)
		{
			if (fileInfo == null)
			{
				return null;
			}
			// 获取应用程序启动目录
			var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			// 获取文件的绝对路径
			var absoluteFilePath = fileInfo.FullName;

			var baseUri = new Uri(baseDirectory);
			var fileUri = new Uri(absoluteFilePath);

			// 计算相对路径
			var relativeUri = baseUri.MakeRelativeUri(fileUri);
			return Uri.UnescapeDataString(relativeUri.ToString().Replace('/', Path.DirectorySeparatorChar));
		}
		
    public static FileInfo RelativePathToFileInfo(string relativePath)
		{
			if (string.IsNullOrWhiteSpace(relativePath))
			{
				return null;
			}
			// 获取应用程序启动目录
			var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			// 将相对路径转换为绝对路径
			var absoluteFilePath = Path.Combine(baseDirectory, relativePath);
			// 创建 FileInfo 对象
			return new FileInfo(absoluteFilePath);
		}

	}
}
