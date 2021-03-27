using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Pattern
{
    public class ProductReceiver
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public ProductReceiver(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public void IncreasePrice(int amount)
        {
            Price += amount;
            Console.WriteLine($"The price for {this.Name} is increased by {amount}");
        }
        public void DecreasePrice(int amount)
        {
            if (amount < Price)
            {
                Price -= amount;
                Console.WriteLine($"The price for {this.Name} is decreased by {amount}");
            }
        }
        public override string ToString()
        {
            return $"Current price for {this.Name} product is {this.Price}";
        }

    }
}
