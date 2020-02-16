using System;
using log4net;
using Sitecore.Configuration;
using Sitecore.Diagnostics;

namespace Foundation.Lighthouse.Diagnostics
{
    /// <summary>
    /// Inspired by SPE log implementation
    /// </summary>
    public class LighthouseLog
    {
        /*

        Loggers may be assigned levels. 
        Levels are instances of the log4net.Core.Level class. 
        The following levels are defined in order of increasing priority:
         
        ALL
        DEBUG
        INFO
        WARN
        ERROR
        FATAL
        OFF

        */

        private static readonly string messagePrefix = string.Empty;

        private static readonly ILog Log;

        static LighthouseLog()
        {
            Log = LogManager.GetLogger("Lighthouse.Diagnostics");

            if (Factory.GetConfigNode("log4net/appender[@name='LighthouseFileAppender']") == null)
            {
                // no own appender - prefix with [Lighthouse] 
                messagePrefix = "[Lighthouse] ";
            }

            if (Log == null)
            {
                Log = LoggerFactory.GetLogger(typeof(LighthouseLog));
                messagePrefix = "[Lighthouse] ";
            }
        }

        public static void Audit(string message, params object[] parameters)
        {
            Assert.ArgumentNotNull(message, "message");
            if (parameters?.Length > 0)
            {
                message = string.Format(message, parameters);
            }
            Log.Info($"{messagePrefix}AUDIT ({Sitecore.Context.User?.Name ?? "unknown user"}) {message}");
        }

        public static void Debug(string message, Exception exception = null)
        {
            Assert.IsNotNull(Log, "Logger implementation was not initialized");
            Assert.ArgumentNotNull(message, "message");
            if (exception == null)
            {
                Log.Debug(FormatMessage(message));
            }
            else
            {
                Log.Debug(FormatMessage(message), exception);
            }
        }

        private static string FormatMessage(string message)
        {
            return messagePrefix != string.Empty ? messagePrefix + message : message;
        }

        public static void Error(string message, Exception exception = null)
        {
            Assert.IsNotNull(Log, "Logger implementation was not initialized");
            if (exception == null)
            {
                Log.Error(FormatMessage(message));
            }
            else
            {
                Log.Error(FormatMessage(message), exception);
            }
        }

        public static void Fatal(string message, Exception exception = null)
        {
            Assert.IsNotNull(Log, "Logger implementation was not initialized");
            if (exception == null)
            {
                Log.Fatal(FormatMessage(message));
            }
            else
            {
                Log.Fatal(FormatMessage(message), exception);
            }
        }

        public static void Info(string message, Exception exception = null)
        {
            Assert.IsNotNull(Log, "Logger implementation was not initialized");
            if (exception == null)
            {
                Log.Info(FormatMessage(message));
            }
            else
            {
                Log.Info(FormatMessage(message), exception);
            }
        }

        public static void Warn(string message, Exception exception = null)
        {
            Assert.IsNotNull(Log, "Logger implementation was not initialized");
            if (exception == null)
            {
                Log.Warn(FormatMessage(message));
            }
            else
            {
                Log.Warn(FormatMessage(message), exception);
            }
        }
    }
}