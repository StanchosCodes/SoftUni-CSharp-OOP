namespace CommandPattern
{
    using IO;
    using Core;
    using IO.Contracts;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command, reader, writer);
            engine.Run();
        }
    }
}
