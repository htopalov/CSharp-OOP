using SimpleApp.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.IO
{
    public class DifferentConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine("different writer.....");
        }
    }
}
