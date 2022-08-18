namespace ConsoleLogger.Factories.Interfaces
{
    using SoftuniLogger.Appenders.Interfaces;
    using SoftuniLogger.Enums;

    internal interface IAppenderFactory
    {
        IAppender Create(string type, string layoutType, ReportLevel level = ReportLevel.Info);
    }
}