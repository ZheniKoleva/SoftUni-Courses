using System;
using System.IO;

using _01.Logger.Layouts;
using _01.Logger.LogFiles;

namespace _01.Logger.Appenders
{
    public class FileAppender : Appender
    {
        private const string filePath = "../../../Output/log.txt";

        public FileAppender(ILayout layout) 
            : base(layout)
        {
        }

        public FileAppender(ILayout layout, ILogFile logFile) 
            : this(layout)
        {
            LogFile = logFile;
        }

        public ILogFile LogFile { get; }

        public override void Append(string datetime, ReportLevel reportLevel, string message)
        {
            Count++;
            string messageToappend = string.Format(Layout.Format, datetime, reportLevel, message);

            LogFile.Write(messageToappend);

            File.AppendAllText(filePath, $"{messageToappend}{Environment.NewLine}");
        }

        public override string GetAppenderInfo()
            => $"{base.GetAppenderInfo()}, File size: {LogFile.Size}";
        
    }
}
