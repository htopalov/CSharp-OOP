using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string name;
        private int weigth;
        private const int minWeigth = 1;
        private const int maxWeigth = 50;

        public Topping(string name,int weigth)
        {
            this.Name = name;
            this.Weigth = weigth;
        }

        public string Name 
        {
            get { return name; } 
            set
            {
                string nameToLower = value.ToLower();
                if (nameToLower == "meat" || nameToLower == "veggies" || nameToLower == "cheese" || nameToLower == "sauce")
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        public int Weigth
        {
            get { return weigth; }
            set
            {
                if (value>= minWeigth && value<= maxWeigth)
                {
                    this.weigth = value;
                }
                else
                {
                    throw new ArgumentException($"{Name} weight should be in the range [{minWeigth}..{maxWeigth}].");
                }
            }
        }
        public double ToppingCalories()
        {
            double toppingModificator = ToppingModificator();
            return 2 * Weigth * toppingModificator;
        }
        private double ToppingModificator()
        {
            string nameToLower = Name.ToLower();
            if (nameToLower == "meat")
            {
                return 1.2;
            }
            else if (nameToLower == "veggies")
            {
                return 0.8;
            }
            else if (nameToLower == "cheese")
            {
                return 1.1;
            }
            return 0.9;
        }
    }
}
