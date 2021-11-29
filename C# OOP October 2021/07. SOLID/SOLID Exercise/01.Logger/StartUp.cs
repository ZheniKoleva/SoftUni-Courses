using System;
using System.Linq;
using System.Reflection;

using _01.Logger.Appenders;
using _01.Logger.Layouts;
using _01.Logger.LogFiles;
using _01.Logger.Loggers;


namespace _01.Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //1. ConsoleAppender
            TestConsoleAppender();

            //2. ConsoleAppender + FileAppender 
            TestConsoleAppenderAndFileAppender();

            //3. XmlLayout
            TestXmlLayout();

            //4. LogFile
            TestLogFile();            

            //5. Command Interpreter
            int appendersCount = int.Parse(Console.ReadLine());

            ILogger logger = GetAppenders(appendersCount);

            string message = Console.ReadLine();

            while (message != "END")
            {
                string[] messageInfo = message
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                LogErrorMessage(logger, messageInfo);

                message = Console.ReadLine();
            }

            Console.WriteLine("Logger info");
            Console.WriteLine(logger.GetLoggerInfo());
        }

       

        private static void LogErrorMessage(ILogger logger, string[] messageInfo)
        {
            string errorLevel = messageInfo[0];

            bool isValidEnum = Enum.TryParse(errorLevel, true, out ReportLevel reportLevel);

            if (!isValidEnum)
            {
                return;                
            }

            string time = messageInfo[1];
            string messageText = messageInfo[2];

            MethodInfo[] methods = logger.GetType().GetMethods();

            foreach (var method in methods)
            {
                if (method.Name == reportLevel.ToString())
                {
                    method.Invoke(logger, messageInfo[1..]);
                }
            }
        }

        private static ILogger GetAppenders(int appendersCount)
        {
            ILogger logger = new Loggers.Logger();

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                IAppender appender = CreateAppender(appenderInfo);

                logger.Appenders.Add(appender);
            }

            return logger;
        }

        private static IAppender CreateAppender(string[] messageInfo)
        {
            string appenderName = messageInfo[0].ToLower();
            string layoutName = messageInfo[1].ToLower();            

            Assembly assembly = Assembly.GetCallingAssembly();

            Type layoutType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == layoutName);

            Type appenderType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == appenderName);

            if (layoutType == null || appenderType == null)
            {
                return null;
            }

            ILayout layout = (ILayout)Activator.CreateInstance(layoutType);

            IAppender appender = null;

            if (appenderType == typeof(ConsoleAppender))
            {
                appender = new ConsoleAppender(layout);
            }
            else if (appenderType == typeof(FileAppender))
            {
                ILogFile logfile = new LogFile();
                appender = new FileAppender(layout, logfile);
            }

            if (messageInfo.Length == 3)
            { 
                string reportLever = messageInfo[2];

                bool isValidEnum = Enum.TryParse(reportLever, ignoreCase: true, out ReportLevel level );

                if (isValidEnum) 
                { 
                    appender.ReportLevel = level;                
                }
            }

            return appender;
        }

        private static void TestLogFile()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportLevel = ReportLevel.Error;

            ILogger logger = new Loggers.Logger(consoleAppender);

            logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");
        }

        private static void TestXmlLayout()
        {
            ILayout xmlLayout = new XmlLayout();
            IAppender consoleAppender = new ConsoleAppender(xmlLayout);
            ILogger logger = new Loggers.Logger(consoleAppender);

            logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");
        }

        private static void TestConsoleAppenderAndFileAppender()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            ILogFile file = new LogFile();
            IAppender fileAppender = new FileAppender(simpleLayout, file);

            ILogger logger = new Loggers.Logger(consoleAppender, fileAppender);
            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }

        private static void TestConsoleAppender()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            ILogger logger = new Loggers.Logger(consoleAppender);

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}
