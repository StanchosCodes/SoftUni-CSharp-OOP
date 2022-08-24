namespace CommandPattern.Core
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    using Common;
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] argsSplit = args.Split();
            string cmdName = argsSplit[0];
            string[] cmdArgs = argsSplit.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type cmdType = assembly?
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{cmdName}Command" && 
                                t.GetInterfaces().Any(i => i == typeof(ICommand)));

            if (cmdType == null)
            {
                throw new InvalidOperationException(string.Format(ErrorMessages.InvalidCommandType, $"{cmdName}Command"));
            }

            object instance = Activator.CreateInstance(cmdType);

            MethodInfo executeMethod = cmdType
                .GetMethods()
                .First(m => m.Name == "Execute");

            string result = (string)executeMethod.Invoke(instance, new object[] { cmdArgs });

            return result;
        }
    }
}
