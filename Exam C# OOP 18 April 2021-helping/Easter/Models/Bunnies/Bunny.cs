using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private List<IDye> dyes;

        public Bunny(string name, int energy)
        {
            this.dyes = new List<IDye>();
            this.Name = name;
            this.Energy = energy;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                this.name = value;
            }
        }

        public int Energy { get; protected set; }

        public ICollection<IDye> Dyes => this.dyes;

        public void AddDye(IDye dye)
        {
            dyes.Add(dye);
        }

        public abstract void Work();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            List<IDye> notFinished = dyes.Where(x => x.IsFinished() == false).ToList();
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Energy: {this.Energy}");
            sb.AppendLine($"Dyes: {notFinished.Count} not finished");

            return sb.ToString().Trim();
        }
    }
}
