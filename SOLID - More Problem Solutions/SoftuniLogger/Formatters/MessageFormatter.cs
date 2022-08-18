namespace SoftuniLogger.Formatters
{
    using Interfaces;
    using SoftuniLogger.Layouts.Interfaces;
    using SoftuniLogger.Messages.Interfaces;

    internal class MessageFormatter : IFormatter
    {
        public MessageFormatter(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public string FormatMessage(IMessage message)
            => string.Format(this.Layout.Format, message.LogTime, message.Level.ToString(), message.MessageText);
    }
}
