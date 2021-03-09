using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animalList = new List<Animal>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string foodInput = Console.ReadLine();
                string[] foodArguments = foodInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] animalArguments = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Animal animal = null;
                Food food = null;
                switch (foodArguments[0])
                {
                    case "Vegetable":
                        food = new Vegetable(int.Parse(foodArguments[1]));
                        break;
                    case "Fruit":
                        food = new Fruit(int.Parse(foodArguments[1]));
                        break;
                    case "Meat":
                        food = new Meat(int.Parse(foodArguments[1]));
                        break;
                    case "Seeds":
                        food = new Seeds(int.Parse(foodArguments[1]));
                        break;
                }
                try
                {
                    switch (animalArguments[0])
                    {
                        case "Cat":
                            animal = new Cat(animalArguments[1], double.Parse(animalArguments[2]), animalArguments[3], animalArguments[4]);
                            Console.WriteLine(animal.ProduceSound());
                            animal.Eat(food);
                            break;
                        case "Tiger":
                            animal = new Tiger(animalArguments[1], double.Parse(animalArguments[2]), animalArguments[3], animalArguments[4]);
                            Console.WriteLine(animal.ProduceSound());
                            animal.Eat(food);
                            break;
                        case "Owl":
                            animal = new Owl(animalArguments[1], double.Parse(animalArguments[2]), double.Parse(animalArguments[3]));
                            Console.WriteLine(animal.ProduceSound());
                            animal.Eat(food);
                            break;
                        case "Hen":
                            animal = new Hen(animalArguments[1], double.Parse(animalArguments[2]), double.Parse(animalArguments[3]));
                            Console.WriteLine(animal.ProduceSound());
                            animal.Eat(food);
                            break;
                        case "Dog":
                            animal = new Dog(animalArguments[1], double.Parse(animalArguments[2]), animalArguments[3]);
                            Console.WriteLine(animal.ProduceSound());
                            animal.Eat(food);
                            break;
                        case "Mouse":
                            animal = new Mouse(animalArguments[1], double.Parse(animalArguments[2]), animalArguments[3]);
                            Console.WriteLine(animal.ProduceSound());
                            animal.Eat(food);
                            break;
                    }
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                animalList.Add(animal);
                input = Console.ReadLine();
              
            }
            foreach (var animal in animalList)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
