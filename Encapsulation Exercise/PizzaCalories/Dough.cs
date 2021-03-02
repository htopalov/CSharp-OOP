using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string technique;
        private int weight;
        private const int minWeight = 1;
        private const int maxWeight = 200;
        public Dough(string flourType,string technique,int weight)
        {
            this.FlourType = flourType;
            this.Technique = technique;
            this.Weight = weight;
        }
        public string FlourType 
        {
            get { return flourType; }
            private set
            {
                string valueToLower = value.ToLower();
                if (valueToLower == "white" || valueToLower == "wholegrain")
                {
                    this.flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public string Technique 
        {
            get { return technique; }
            set
            {
                string valueToLower = value.ToLower();
                if (valueToLower == "crispy" || valueToLower == "chewy" || valueToLower == "homemade")
                {
                    this.technique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public int Weight
        {
            get { return weight; }
            set
            {
                if (value>= minWeight && value<= maxWeight)
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentException($"Dough weight should be in the range [{minWeight}..{maxWeight}].");
                }
            }
        }
        public double DoughCalories()
        {
            double flourModificator = FlourModificator();
            double techniqueModificator = TechniqueModificator();
            return 2 * this.Weight * flourModificator * techniqueModificator;
        }

        private double FlourModificator()
        {
            string typeToLower = FlourType.ToLower();
            if (typeToLower == "white")
            {
                return 1.5;
            }
            return 1.0;
        }
        private double TechniqueModificator()
        {
            string techniqueToLower = Technique.ToLower();
            if (techniqueToLower == "crispy")
            {
                return 0.9;
            }
            else if (techniqueToLower == "chewy")
            {
                return 1.1;
            }
            return 1.0;
        }
    }
}
