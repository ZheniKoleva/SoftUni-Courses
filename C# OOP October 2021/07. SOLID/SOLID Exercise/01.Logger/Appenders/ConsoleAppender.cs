using System;

using _01.Logger.Layouts;

namespace _01.Logger.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string datetime, ReportLevel reportLevel, string message)
        {
            Count++;
            string messageToAppend = string.Format(Layout.Format, datetime, reportLevel, message);
            Console.WriteLine(messageToAppend);
        }

       
    }
}