using P01._HelloWorld;
using System;

namespace P01._HelloWorld_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorld hello = new HelloWorld();
            Console.WriteLine(hello.Greeting(DateTime.Now, "Ivan"));
        }
    }
}
