namespace CommandPattern.Core.Commands
{
    using Contracts;
    using System;

    public class ExitCommand : ICommand
    {
        private const int CodeToExitSuccesfuly = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(CodeToExitSuccesfuly);

            return null;
        }
    }
}
