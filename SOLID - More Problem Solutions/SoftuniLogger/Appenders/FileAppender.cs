namespace SoftuniLogger.Appenders
{
    using Interfaces;
    using SoftuniLogger.IO.Interfaces;
    using SoftuniLogger.Layouts.Interfaces;
    using SoftuniLogger.Messages.Interfaces;
    using Formatters.Interfaces;
    using Formatters;
    using SoftuniLogger.Enums;

    public class FileAppender : IFileAppender
    {
        private readonly IFormatter formatter;

        private FileAppender()
        {
            this.Count = 0;
        }
        public FileAppender(ILayout layout, ReportLevel level, ILogFile logFile)
            : this()
        {
            this.Layout = layout;
            this.LogFile = logFile;
            this.Level = level;
            this.formatter = new MessageFormatter(this.Layout);
        }
        public int Count { get; }
        public ILogFile LogFile { get; }
        public ILayout Layout { get; }

        public ReportLevel Level { get; }

        public void Append(IMessage message)
        {
            string formattedMessage = this.formatter.FormatMessage(message);
            this.LogFile.Write(formattedMessage);
        }

        public void SaveLogFile(string fileName)
        {
            this.LogFile.SaveAs(fileName);
        }
    }
}
