using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int nameMinLength = 1;
        private const int nameMaxLength = 15;
        private const int maxToppingCount = 10;
        private const int minToppingCount = 0   ;
        private string name;
        private Dough dough;
        private List<Topping> toppingList;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppingList = new List<Topping>();
        }


        public string Name 
        {
            get { return name; }
            set
            {
                if (value.Length > nameMinLength && value.Length < nameMaxLength)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException($"Pizza name should be between {nameMinLength} and {nameMaxLength} symbols.");
                }
            }
        }
        public void AddTopping(Topping topping)
        {
            if (toppingList.Count <10)
            {
                toppingList.Add(topping);
            }
            else
            {
                throw new ArgumentException($"Number of toppings should be in range [{minToppingCount}..{maxToppingCount}].");
            }
        }
        public double PizzaCalories()
        {
            return this.dough.DoughCalories() + this.toppingList.Sum(t => t.ToppingCalories());
        }
    }
}
