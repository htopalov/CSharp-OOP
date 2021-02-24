using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList(new string[] { "pesho","gosho","ivancho","stamat"});
            Console.WriteLine(list.Count);
            Console.WriteLine(list.RandomString()); 
            Console.WriteLine(list.RandomString()); 
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.Count);
        }
    }
}
