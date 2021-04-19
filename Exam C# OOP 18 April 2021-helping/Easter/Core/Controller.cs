using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        private Workshop workshop;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
            this.workshop = new Workshop();

        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;
            switch (bunnyType)
            {
                case "HappyBunny":
                    bunny = new HappyBunny(bunnyName);
                    break;
                case "SleepyBunny":
                    bunny = new SleepyBunny(bunnyName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            bunnies.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var dye = new Dye(power);
            var bunny = bunnies.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            bunny.AddDye(dye);

            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            var egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            var egg = eggs.Models.FirstOrDefault(x => x.Name == eggName);
            var energyBunnies = bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x=>x.Energy).ToList();
            if (energyBunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            IBunny energyBunny = null;

            while (energyBunnies.Count > 0 && energyBunnies.Any(x=>x.Dyes.Any(x=>x.IsFinished() == false)))
            {
                energyBunny = energyBunnies.First(x=>x.Dyes.Any(x=>x.IsFinished() == false));
                workshop.Color(egg, energyBunny);
                if (energyBunny.Energy == 0)
                {
                    bunnies.Remove(energyBunny);
                }
                if (egg.IsDone() == true)
                {
                    break;
                }
                if (energyBunny.Dyes.All(x => x.IsFinished() == true))
                {
                    break;
                }
            }

            if (egg.IsDone() == true)
            {
                return $"Egg {eggName} is done.";
            }
            else
            {
                return $"Egg {eggName} is not done.";
            }

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            List<IEgg> coloredEggs = eggs.Models.Where(x => x.IsDone() == true).ToList();
            sb.AppendLine($"{coloredEggs.Count} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine(bunny.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
