using SimpleApp.Contracts;
using SimpleApp.IO;
using SimpleDependencyInjectorContainer.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.DIC
{
    public class ConfigureDI : AbstractModule
    {
        public override void Configure()
        {
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IWriter, ConsoleWriter>();
            CreateMapping<IWriter, DifferentConsoleWriter>();
        }
    }
}
