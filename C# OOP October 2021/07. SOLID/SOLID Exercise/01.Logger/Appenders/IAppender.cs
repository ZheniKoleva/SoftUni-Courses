using _01.Logger.Layouts;

namespace _01.Logger.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public int Count { get; }

        public void Append(string datetime, ReportLevel reportLevel, string message);

        public string GetAppenderInfo();
    }
}