using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<IBirthdate> identities = new List<IBirthdate>();
            while (input[0].ToLower() != "end")
            {
                if (input[0].ToLower() == "citizen")
                {
                    IBirthdate citizen = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
                    identities.Add(citizen);
                }
                else if (input[0].ToLower() == "pet")
                {
                    IBirthdate pet = new Pet(input[1], input[2]);
                    identities.Add(pet);
                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            string birthYear = Console.ReadLine();
            foreach (var identity in identities)
            {
                if (identity.Birthdate.EndsWith(birthYear))
                {
                    Console.WriteLine(identity.Birthdate);
                }

            }
        }
    }
}
