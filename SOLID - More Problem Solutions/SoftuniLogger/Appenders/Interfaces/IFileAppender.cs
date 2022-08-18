namespace SoftuniLogger.Appenders.Interfaces
{
    using IO.Interfaces;

    public interface IFileAppender : IAppender
    {
        ILogFile LogFile { get; }

        void SaveLogFile(string fileName);
    }
}
