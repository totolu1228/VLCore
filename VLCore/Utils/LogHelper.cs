using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VLCore.Utils
{
    public static class LogHelper
    {
        private static readonly ILog log = LogManager.GetLogger("Logger");

        private static void SetConfig()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout
            {
                ConversionPattern = "%date [%thread] %-5level %logger - %message%newline"
            };
            patternLayout.ActivateOptions();

            RollingFileAppender roller = new RollingFileAppender
            {
                AppendToFile = true,
                File = @"Logs\",
                RollingStyle = RollingFileAppender.RollingMode.Date,
                DatePattern = "\"Log_\"yyyyMMdd\".log\"",
                StaticLogFileName = false,
                Layout = patternLayout
            };

            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            MemoryAppender memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);

            hierarchy.Root.Level = Level.All;
            hierarchy.Configured = true;
        }

        public static void LogInfo(string Message)
        {
            if (!log.IsInfoEnabled)
                SetConfig();
            log.Info(Message);
        }

        public static void LogInfo(string Message, Exception ex)
        {
            if (!log.IsInfoEnabled)
                SetConfig();
            log.Info(Message, ex);
        }

        public static void ErrorInfo(string Message)
        {
            if (!log.IsInfoEnabled)
                SetConfig();
            log.Error(Message);
        }

        public static void ErrorInfo(string Message, Exception ex)
        {
            if (!log.IsInfoEnabled)
                SetConfig();
            log.Error(Message, ex);
        }

        public static void DebugInfo(string Message)
        {
            if (!log.IsInfoEnabled)
                SetConfig();
            log.Debug(Message);
        }

        public static void DebugInfo(string Message, Exception ex)
        {
            if (!log.IsInfoEnabled)
                SetConfig();
            log.Debug(Message, ex);
        }
    }
}
