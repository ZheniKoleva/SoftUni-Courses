using System.Collections.Generic;

using _01.Logger.Appenders;

namespace _01.Logger.Loggers
{
    public interface ILogger
    {
        public ICollection<IAppender> Appenders { get; }

        public void Info(string dateTime, string message);

        public void Error(string dateTime, string message);

        public void Warning(string dateTime, string message);

        public void Critical(string dateTime, string message);

        public void Fatal(string dateTime, string message);

        public string GetLoggerInfo();

    }
}