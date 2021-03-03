using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<IIdentity> identities = new List<IIdentity>();
            while (input[0] != "End")
            {
                if (input.Length == 2)
                {
                    IIdentity robot = new Robot(input[0], input[1]);
                    identities.Add(robot);
                }
                else if(input.Length == 3)
                {
                    IIdentity citizen = new Citizen(input[0], int.Parse(input[1]), input[2]);
                    identities.Add(citizen);
                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            string fakeId = Console.ReadLine();
            foreach (var identity in identities)
            {
                if (identity.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(identity.Id);
                }
            }
        }
    }
}
