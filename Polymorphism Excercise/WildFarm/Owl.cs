using System;

namespace WildFarm
{
    public class Owl : Bird
    {
        private const double foodCoefficient = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
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
            return "Hoot Hoot";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} " + base.ToString();
        }
    }
}
