using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Text;

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
        //Log.Logger = new LoggerConfiguration()
        //    .WriteTo.Console()
        //    .WriteTo.File(...)
        //    .WriteTo.SomewhereElse(...)
        // So, according to Serilog GIT PRs - this is possible to write to multiple sinks

        // Log levels:
        // - Info
        // - Warning
        // - Error
        // - Debug
        static Dictionary<LogType, Logger> _loggers = new Dictionary<LogType, Logger>();

        public static Logger GetLogger(LogType logType)
        {
            throw new NotImplementedException();
        }
    }
}
