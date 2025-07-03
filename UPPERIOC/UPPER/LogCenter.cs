using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using UPPERIOC.UPPER.enums;
using UPPERIOC.UPPER.MainApplication.Log_;

namespace UPPERIOC.UPPER
{
    public static class LogCenter
    {
        // 使用线程安全集合
        private static readonly ConcurrentBag<ILog> _loggers = new ConcurrentBag<ILog>();

        /// <summary>
        /// 注册单个日志器
        /// </summary>
        public static void AddLogger(ILog logger)
        {
            if (logger == null) return;
            _loggers.Add(logger);
        }

        /// <summary>
        /// 批量注册日志器
        /// </summary>
        public static void AddAllLoggers(IEnumerable<ILog> loggers)
        {
            if (loggers == null) return;
            foreach (var logger in loggers)
            {
                if (logger != null)
                    _loggers.Add(logger);
            }
        }

        /// <summary>
        /// 打印日志
        /// </summary>
        public static void Log(LogType type, string message)
        {
            foreach (var logger in _loggers)
            {
                if (logger?.CanLogType?.Contains(type) == true)
                {
                    logger.Log(type, message);
                }
            }
        }
    }
}
