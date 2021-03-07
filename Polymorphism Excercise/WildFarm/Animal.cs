using System;

namespace WildFarm
{
    public abstract class Animal
    {
        public Animal(string name,double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }
        public string Name { get; protected set; }
        public double Weight { get;protected set; }
        public int FoodEaten { get;protected set; }
        public virtual string ProduceSound()
        {
            return string.Empty;
        }
        public abstract void Eat(Food food);
    }
}
