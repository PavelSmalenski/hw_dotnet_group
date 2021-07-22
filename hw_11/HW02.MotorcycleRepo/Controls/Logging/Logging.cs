using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW02.MotorcycleRepo.Controls.Logging
{
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

        public static Logger GetLogger(LogType logType)
        {
            throw new NotImplementedException();
        }
    }
}
