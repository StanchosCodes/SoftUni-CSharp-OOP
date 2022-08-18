namespace ConsoleLogger.Factories.Interfaces
{
    using SoftuniLogger.Layouts.Interfaces;

    internal interface ILayoutFactory
    {
        ILayout Create(string type);
    }
}