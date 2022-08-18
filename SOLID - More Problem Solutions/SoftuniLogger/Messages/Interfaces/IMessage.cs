namespace SoftuniLogger.Messages.Interfaces
{
    using Enums;

    public interface IMessage
    {
        string MessageText { get; }

        string LogTime { get; }
        ReportLevel Level { get; }
    }
}
