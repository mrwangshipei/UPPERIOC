using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPERIOC.UPPER.MainApplication.Log_
{
    public static class LogManager
    {
        public static void Init(IEnumerable<ILog> logs)
        {
            var validLogs = logs?.ToArray() ?? Array.Empty<ILog>();
            LogCenter.AddAllLoggers(validLogs);
        }
    }

}
