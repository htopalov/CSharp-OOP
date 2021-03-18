using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandType)
        {
            Type type = Assembly.GetEntryAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name == $"{commandType}Command");
            if (type == null)
            {
                throw new ArgumentException("No such type");
            }

            ICommand command = (ICommand)Activator.CreateInstance(type);

            return command;
        }
    }
}
