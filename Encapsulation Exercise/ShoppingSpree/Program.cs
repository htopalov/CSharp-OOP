using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Person> peopleList = new List<Person>();
                List<Product> productsList = new List<Product>();
                string[] people = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                string[] products = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < people.Length; i++)
                {
                    string[] currentPerson = people[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    peopleList.Add(new Person(currentPerson[0], decimal.Parse(currentPerson[1])));
                }
                for (int i = 0; i < products.Length; i++)
                {
                    string[] currentProduct = products[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    productsList.Add(new Product(currentProduct[0], decimal.Parse(currentProduct[1])));
                }
                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string name = arguments[0];
                    string product = arguments[1];
                    var currentPerson = peopleList.Find(p => p.Name == name);
                    var currentProduct = productsList.Find(p => p.Name == product);
                    currentPerson.Shop(currentProduct);
                    command = Console.ReadLine();
                }
                foreach (var person in peopleList)
                {
                    if (person.ProductList.Count == 0)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                    else
                    {
                        Console.Write($"{person.Name} - ");
                        Console.WriteLine(string.Join(", ", person.ProductList.Select(p=>p.Name)));
                    }
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
