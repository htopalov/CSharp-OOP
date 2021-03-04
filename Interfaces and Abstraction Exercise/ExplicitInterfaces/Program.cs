using System;

namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                IPerson person = new Citizen(input[0], input[1], int.Parse(input[2]));
                IResident resident = new Citizen(input[0], input[1], int.Parse(input[2]));
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName() + person.GetName());
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
