using _01.Logger.Layouts;

namespace _01.Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            Layout = layout;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public int Count { get; protected set; }

        public abstract void Append(string datetime, ReportLevel reportLevel, string message);

        public virtual string GetAppenderInfo()
            => $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, " +
            $"Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {Count}";
        
    }
}
