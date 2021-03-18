using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICommandFactory factory;

        public CommandInterpreter()
        {
            this.factory = new CommandFactory();
        }
        public string Read(string args)
        {
            string[] inputArguments = args.Split();
            string commandType = inputArguments[0];
            string[] arguments = inputArguments.Skip(1).ToArray();

            ICommand command = this.factory.CreateCommand(commandType);

            return command.Execute(arguments);
        }
    }
}
