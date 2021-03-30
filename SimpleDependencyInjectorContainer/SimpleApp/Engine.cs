using SimpleApp.Contracts;
using SimpleApp.IO;
using SimpleDependencyInjectorContainer.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp
{
    public class Engine
    {
        private IWriter writer;
        private IReader reader;

        [Inject]
        public Engine(IReader reader,[Named(typeof(DifferentConsoleWriter))]IWriter writer, int x)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            int i = 0;
            while (i < 10)
            {
                writer.Write("working");
                i++;
            }
        }
    }
}
