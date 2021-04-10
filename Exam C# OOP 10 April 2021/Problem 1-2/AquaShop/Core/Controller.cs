using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            switch(aquariumType)
            {
                case "FreshwaterAquarium":
                    aquarium = new FreshwaterAquarium(aquariumName);
                    break;
                case "SaltwaterAquarium":
                    aquarium = new SaltwaterAquarium(aquariumName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            switch(decorationType)
            {
                case "Ornament":
                    decoration = new Ornament();
                    break;
                case "Plant":
                    decoration = new Plant();
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            switch(fishType)
            {
                case "FreshwaterFish":
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case "SaltwaterFish":
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            
            if (fish.GetType().Name == nameof(FreshwaterFish) && aquarium.GetType().Name == nameof(FreshwaterAquarium))
            {
                aquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else if (fish.GetType().Name == nameof(SaltwaterFish) && aquarium.GetType().Name == nameof(SaltwaterAquarium))
            {
                aquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else
            {
                return OutputMessages.UnsuitableWater;
            }
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var totalValue = aquarium.Fish.Sum(x => x.Price) + aquarium.Decorations.Sum(x => x.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, totalValue);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decorationToAdd = decorations.FindByType(decorationType);
            if (decorationToAdd == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Decorations.Add(decorationToAdd);
            decorations.Remove(decorationToAdd);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
