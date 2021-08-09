using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace HW02.MotorcycleRepo.Controls.Logging
{
    /// <summary>
    /// Available log types
    /// </summary>
    public enum LogType
    {
        Application,
        CRUD,
        ConsoleInOut,
        ProgramFinish,
        Exception
    }

    /// <summary>
    /// Implementation of singleton for loggers of LogType type
    /// </summary>
    static class Logging
    {
        static Dictionary<LogType, Logger> _loggers = new Dictionary<LogType, Logger>();

        static Logging()
        {
            // Log levels:
            // - Info
            // - Warning
            // - Error
            // - Debug

            string startTime = DateTime.Now.ToString("yyyy'_'MM'_'dd'T'HH'-'mm'-'ss");
            foreach (var loggerTypeName in Enum.GetNames(typeof(LogType)))
            {
                _loggers.Add(
                    (LogType)Enum.Parse(typeof(LogType), loggerTypeName),
                    new LoggerConfiguration()
                        .WriteTo.Console()
                        .WriteTo.File(path: Path.Combine(Environment.CurrentDirectory, "logs", $"log-{loggerTypeName}-{startTime}.log"), rollingInterval: RollingInterval.Hour)
                        .CreateLogger());
            }
        }

        public static Logger GetLogger(LogType logType)
        {
            return _loggers[logType];
        }
    }
}
