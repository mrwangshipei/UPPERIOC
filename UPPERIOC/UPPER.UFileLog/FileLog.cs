using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.enums;
using UPPERIOC.UPPER.UFileLog.IConfiguation;
using UPPERIOC.UPPER.ILOG;

namespace UPPERIOC.UPPER.UFileLog
{
    public class FileLog : ILog
    {
        IFileLogConfiguation Config;
        public FileLog(IFileLogConfiguation Config)
        {
            if (Config == null)
            {
                throw new Exception("请将FileLog的配置类IFileLogConfiguation 实现交托容器管理");
            }
            this.Config = Config;
        }
        public void Log(LogType LogType, string Msg)
        {
            if (!Config.WhichTypePrint.Contains(LogType))
            {
                return;
            }
            var logtime = DateTime.Now;
            //路径
            var diname = Path.Combine(Environment.CurrentDirectory, Config.DirectoryName);
            DirectoryInfo di = new DirectoryInfo(diname);
            if (!Directory.Exists(diname))
            {
                Directory.CreateDirectory(diname);
            }
            //文件名
            var filename = logtime.ToString(Config.FileNameTimeFormat) + Config.DefaultExt;
            DelTimeOutLog(di, logtime);
            var fullname = Path.Combine(diname, filename);
            if (!File.Exists(fullname))
            {
                File.Create(fullname).Close();
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(Enum.GetName(LogType.GetType(), LogType));
            sb.Append(" - ");
            sb.Append(logtime.ToLocalTime().ToString());
            sb.Append(":");
            sb.Append(Msg);
            sb.Append("\n");
            File.AppendAllText(fullname, sb.ToString());
        }

        private void DelTimeOutLog(DirectoryInfo di, DateTime now)
        {
            foreach (var item in di.GetFiles())
            {
                if ((now - item.LastWriteTime).TotalHours > Config.HowManyHourSave)
                {
                    try
                    {

                        item.Delete();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
    }
}
