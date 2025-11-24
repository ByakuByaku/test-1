using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace patterns
{
    internal class logger
    {
        private static logger _instance;
        private logLevel _minlevel;
        public static logger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new logger();
                return _instance;
            }
        }

        private logger() 
        {
            _minlevel = logLevel.Debug;
        }
        public void setminlogLevel(logLevel level)
        {
            _minlevel = level;
        }

        public void LogTrace(string message) => Log(logLevel.Trace, message);
        public void LogDebug(string message) => Log(logLevel.Debug, message);
        public void LogInformation(string message) => Log(logLevel.Information, message);
        public void LogWarning(string message) => Log(logLevel.Warning, message);
        public void LogError(string message, Exception ex = null) => Log(logLevel.Error, message, ex);
        public void LogCritical(string message, Exception ex = null) => Log(logLevel.Critical, message, ex);

        public void Log(logLevel level, string message, Exception exception = null)
        {
            if (level < logLevel.Information)
            {
                return;
            }
            try
            {
                string mes = formatMessage(level, message, exception);
                Console.WriteLine(mes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LOGGER ERROR: {ex.Message}");
            }
                

            
        }

        private string formatMessage(logLevel level, string message, Exception exception = null)
        {
            var timestamp = DateTime.UtcNow;
            var levelstr = level.ToString().ToUpper();
            var fullMessage = $"[{message}][{levelstr}][{timestamp}]";
            if (exception != null)
            {
                fullMessage += $"\nException: {exception.Message}\nStack Trace: {exception.StackTrace}";
            }
            return fullMessage;
        }
    }

    public enum logLevel
    {
        Trace = 0,
        Debug = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
        Critical = 5
    }

}
