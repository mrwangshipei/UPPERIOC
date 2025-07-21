using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC;
using UPPERIOC.UPPER;
using UPPERIOC.UPPER.enums;
using UPPERIOC.UPPER.IOC.Center.Configuation;
using UPPERIOC.UPPER.UFileLog.IConfiguation;
using Xunit;

namespace UPPERTest
{
    public class MFileLogTest
    {
        public class FIleLogConfig : IFileLogConfiguation
        {
            public bool PrintMs { get => true; set => throw new NotImplementedException(); }
            public string DirectoryName { get => "UPPER"; set => throw new NotImplementedException(); }
            public string DefaultExt { get =>".txt"; set => throw new NotImplementedException(); }
            public List<LogType> WhichTypePrint { get => Enum.GetValues<LogType>().ToList(); set => throw new NotImplementedException(); }
            public string FileNameTimeFormat { get => "yyyyMMdd"; set => throw new NotImplementedException(); }
            public int HowManyHourSave { get => 48; set => throw new NotImplementedException(); }

            public bool MutiFileName => false;
        }
        [Fact]
        public void MFileWriten()
        {
            // 启动应用并注册日志配置
            UPPERIOCApplication.RunInstance(md =>
            {
                md.UPPERLogFileMoudle(new FIleLogConfig());
            });

            // 写入日志
            LogCenter.Log(LogType.Error, "Hello,UPPER");
            LogCenter.Log(LogType.Info, "Hello,UPPER");

            // 获取日志文件路径
            string logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UPPER");
            string logFileName = $"{DateTime.Now:yyyyMMdd}.txt";
            string logFilePath = Path.Combine(logFolder, logFileName);

            // 等待日志写入完成（如有异步写入）
            System.Threading.Thread.Sleep(500); // 可视情况调整

            Assert.True(File.Exists(logFilePath), $"日志文件未找到: {logFilePath}");

            string content = File.ReadAllText(logFilePath);

            // 验证内容
            Assert.Contains("Error", content);
            Assert.Contains("Info", content);
            Assert.Contains("Hello,UPPER", content);

            // 删除日志文件（清理）
            File.Delete(logFilePath);
            Assert.False(File.Exists(logFilePath), "日志文件未成功删除");
        }
    }
}
