using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }
                this.name = value;
            }
        }

        public int EnergyRequired { get; private set; }

        public void GetColored()
        {
            if (EnergyRequired - 10 < 0)
            {
                EnergyRequired = 0;
            }
            else
            {
                EnergyRequired -= 10;
            }
        }

        public bool IsDone()
        {
            return EnergyRequired == 0;
        }
    }
}
