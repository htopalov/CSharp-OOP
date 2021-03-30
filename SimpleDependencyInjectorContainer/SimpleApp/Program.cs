using SimpleApp.DIC;
using SimpleDependencyInjectorContainer.Injectors;
using System;

namespace SimpleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureDI module = new ConfigureDI();
            Injector injector = new Injector(module);
            Engine engine = injector.Inject<Engine>();
            engine.Start();
        }
    }
}
