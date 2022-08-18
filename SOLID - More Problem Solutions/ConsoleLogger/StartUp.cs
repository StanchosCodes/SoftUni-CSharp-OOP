
namespace ConsoleLogger
{
    using Core;
    using Factories;
    using Core.Interfaces;
    using Factories.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            ILayoutFactory layoutFactory = new LayoutFactory();
            IAppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            IEngine engine = new Engine(appenderFactory);
            engine.Start();
        }
    }
}
