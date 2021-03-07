using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            BaseHero hero = null;
            while (count != n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                switch (type)
                {
                    case "Druid":
                        hero = new Druid(name);
                        heroes.Add(hero);
                        count++;
                        break;
                    case "Paladin":
                        hero = new Paladin(name);
                        heroes.Add(hero);
                        count++;
                        break;
                    case "Rogue":
                        hero = new Rogue(name);
                        heroes.Add(hero);
                        count++;
                        break;
                    case "Warrior":
                        hero = new Warrior(name);
                        heroes.Add(hero);
                        count++;
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            int totalHeroesPower = heroes.Sum(x => x.Power);
            foreach (var currentHero in heroes)
            {
                Console.WriteLine(currentHero.CastAbility());
            }
            if (totalHeroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
