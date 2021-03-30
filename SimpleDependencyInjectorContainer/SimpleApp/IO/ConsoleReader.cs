using SimpleApp.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.IO
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}
