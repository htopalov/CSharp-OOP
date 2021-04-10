using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fish;

        public Aquarium(string name, int capacity)
        {
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => this.decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count < Capacity)
            {
                this.fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
      
        }

        public void Feed()
        {
            foreach (var fish in fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if (fish.Count == 0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                string[] names = new string[Fish.Count];
                int i = 0;
                foreach (var fish in fish)
                {
                    names[i] = fish.Name;
                    i++;
                }
                sb.AppendLine("Fish: " + string.Join(", ", names));
            }
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().Trim();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
    }
}
