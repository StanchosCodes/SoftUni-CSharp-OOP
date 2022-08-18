
namespace SoftuniLogger.Formatters.Interfaces
{
    using Messages.Interfaces;
    using Layouts.Interfaces;

    internal interface IFormatter
    {
        ILayout Layout { get; }
        string FormatMessage(IMessage message);
    }
}
