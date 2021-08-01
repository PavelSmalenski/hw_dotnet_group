using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;

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

        internal static void Configuration()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Minute)
            .CreateLogger();
        }
        public static Logger GetLogger(LogType logType)
        {
            throw new NotImplementedException();
        }
    }
}
