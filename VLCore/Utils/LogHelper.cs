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
    /// <summary>
    /// log helper
    /// </summary>
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

        /// <summary>
        /// log info
        /// </summary>
        public static void LogInfo(string msg)
        {
            if (!log.IsInfoEnabled)
                SetConfig();
            log.Info(msg);
        }

        /// <summary>
        /// log info
        /// </summary>
        public static void LogInfo(string msg, Exception ex)
        {
            if (!log.IsInfoEnabled)
                SetConfig();
            log.Info(msg, ex);
        }

        /// <summary>
        /// log error
        /// </summary>
        public static void LogError(string msg)
        {
            if (!log.IsInfoEnabled)
                SetConfig();
            log.Error(msg);
        }

        /// <summary>
        /// log error
        /// </summary>
        public static void LogError(string msg, Exception ex)
        {
            if (!log.IsInfoEnabled)
                SetConfig();
            log.Error(msg, ex);
        }

        /// <summary>
        /// log debug
        /// </summary>
        public static void LogDebug(string msg)
        {
            if (!log.IsInfoEnabled)
                SetConfig();
            log.Debug(msg);
        }

        /// <summary>
        /// log debug
        /// </summary>
        public static void LogDebug(string msg, Exception ex)
        {
            if (!log.IsInfoEnabled)
                SetConfig();
            log.Debug(msg, ex);
        }
    }
}
