
namespace SoftuniLogger.Appenders
{
    using System;
    using Interfaces;
    using Formatters;
    using Layouts.Interfaces;
    using Messages.Interfaces;
    using Formatters.Interfaces;
    using SoftuniLogger.Enums;

    public class ConsoleAppender : IAppender
    {
        private readonly IFormatter formatter;
        private ConsoleAppender()
        {
            this.Count = 0;
        }

        public ConsoleAppender(ILayout layout, ReportLevel level)
            : this ()
        {
            this.Level = level;
            this.Layout = layout;
            this.formatter = new MessageFormatter(this.Layout);
        }
        public int Count { get; private set; }

        public ILayout Layout { get; }

        public ReportLevel Level { get; }

        public void Append(IMessage message)
        {
            string formattedMessage = this.formatter.FormatMessage(message);
            Console.WriteLine(formattedMessage);
            this.Count++;
        }
    }
}
