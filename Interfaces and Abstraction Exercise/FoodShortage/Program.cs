using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,IBuyer> buyers = new Dictionary<string, IBuyer>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 4)
                {
                    IBuyer citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    buyers.Add(input[0],citizen);
                }
                else if(input.Length == 3)
                {
                    IBuyer rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    buyers.Add(input[0],rebel);
                }
            }
            string name = Console.ReadLine();
            while (name != "End")
            {
                if (buyers.ContainsKey(name))
                {
                    buyers[name].BuyFood();
                }
                name = Console.ReadLine();
            }
            Console.WriteLine(buyers.Values.Sum(x=>x.Food));
        }
    }
}
