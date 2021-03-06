﻿using System;

namespace WildFarm
{
    public class Tiger : Feline
    {
        private const double foodCoefficient = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                this.Weight += food.Quantity * foodCoefficient;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} " + base.ToString();
        }
    }
}
