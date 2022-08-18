namespace SoftuniLogger.Loggers
{
    using Enums;
    using Common;
    using Layouts;
    using Messages;
    using Loggers.Interfaces;
    using Messages.Interfaces;
    using Appenders.Interfaces;
    using System.Collections.Generic;

    public class Logger : IAppenderCollection, ILogger
    {
        private readonly ICollection<IAppender> appenders;

        private Logger()
        {
            this.appenders = new List<IAppender>();
        }
        public Logger(params IAppender[] appenders)
            : this()
        {
            this.appenders.AddRange(appenders);
        }
        public IReadOnlyCollection<IAppender> Appenders
            => this.appenders.AsReadOnly();

        public void AddAppender(IAppender appender)
        {
            this.appenders.Add(appender);
        }

        public bool RemoveAppender(IAppender appender)
        {
            return this.appenders.Remove(appender);
        }

        public void Clear()
        {
            this.appenders.Clear();
        }

        public void Critical(string logTime, string message)
        {
            this.LogMessage(logTime, message, ReportLevel.Critical);
        }

        public void Error(string logTime, string message)
        {
            this.LogMessage(logTime, message, ReportLevel.Error);
        }

        public void Fatal(string logTime, string message)
        {
            this.LogMessage(logTime, message, ReportLevel.Fatal);
        }

        public void Info(string logTime, string message)
        {
            this.LogMessage(logTime, message, ReportLevel.Info);
        }


        public void Warning(string logTime, string message)
        {
            this.LogMessage(logTime, message, ReportLevel.Warning);
        }

        private void LogMessage(string logTime, string messageText, ReportLevel level)
        {
            IMessage message = new Message(logTime, messageText, level);

            foreach (IAppender appender in this.Appenders)
            {
                if (appender.Level <= level)
                {
                    appender.Append(message);
                }
            }
        }

        public void SaveLogs(string fileName)
        {
            int counter = 1;
            foreach (IAppender appender in this.Appenders)
            {
                if (appender is IFileAppender fileAppender)
                {
                    if (fileAppender.Layout.GetType() == typeof(XmlLayout))
                    {
                        fileAppender.SaveLogFile($"{fileName}_{counter++}.xml");
                    }
                    else
                    {
                        fileAppender.SaveLogFile($"{fileName}_{counter++}.txt");
                    }
                }
            }
        }
    }
}
