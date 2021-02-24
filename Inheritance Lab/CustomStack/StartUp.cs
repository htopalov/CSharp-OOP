using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings fff = new StackOfStrings();
            Console.WriteLine(fff.IsEmpty());
            Console.WriteLine(fff.AddRange(new string[] { "pesho", "gosho", "ivan" })); 

        }
    }
}
