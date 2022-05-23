using System.Text;
using System.Collections.Generic;

using _01.Logger.Appenders;

namespace _01.Logger.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = new List<IAppender>(appenders);
        }

        public ICollection<IAppender> Appenders { get; }

        public void Info(string dateTime, string message)
            => LogData(dateTime, ReportLevel.Info, message);             

        public void Warning(string dateTime, string message)
            => LogData(dateTime, ReportLevel.Warning, message);

        public void Error(string dateTime, string message)
            => LogData(dateTime, ReportLevel.Error, message);

        public void Critical(string dateTime, string message)
            => LogData(dateTime, ReportLevel.Critical, message);

        public void Fatal(string dateTime, string message)
            => LogData(dateTime, ReportLevel.Fatal, message);

        public string GetLoggerInfo()
        {
            StringBuilder output = new StringBuilder();

            foreach (IAppender appender in Appenders)
            {
                output.AppendLine(appender.GetAppenderInfo());            
            }

            return output.ToString().TrimEnd();
        }

        private void LogData(string dateTime, ReportLevel errorLevel, string message)
        {
            foreach (var currentAppender in Appenders)
            {
                if (currentAppender.ReportLevel <= errorLevel)
                {
                    currentAppender.Append(dateTime, errorLevel, message);
                }

            }
        }

    }
}
