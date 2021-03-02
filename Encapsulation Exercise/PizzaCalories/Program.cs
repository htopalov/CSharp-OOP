using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split()[1];
                string[] doughInput = Console.ReadLine().Split();
                string flourType = doughInput[1];
                string technique = doughInput[2];
                int weight = int.Parse(doughInput[3]);

                Dough dough = new Dough(flourType, technique, weight);
                Pizza pizza = new Pizza(pizzaName, dough);


                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }
                    string[] arguments = input.Split();
                    string toppingName = arguments[1];
                    int toppingWeight = int.Parse(arguments[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);
                    pizza.AddTopping(topping);
                }
                Console.WriteLine($"{pizzaName} - {pizza.PizzaCalories():f2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
