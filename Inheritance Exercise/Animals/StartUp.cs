using System;
namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (true)
            {
                if (int.Parse(data[1]) <= 0 || data[0] == null || data[2] == null)
                {
                    throw new ArgumentException("Invalid input!");
                }

                if (command == "Cat")
                {
                    Cat cat = new Cat(data[0], int.Parse(data[1]), data[2]);
                    Console.WriteLine(cat.GetType().Name);
                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                }
                else if(command == "Dog")
                {
                    Dog dog = new Dog(data[0], int.Parse(data[1]), data[2]);
                    Console.WriteLine(dog.GetType().Name);
                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());
                }
                else if(command == "Frog")
                {
                    Frog frog = new Frog(data[0], int.Parse(data[1]), data[2]);
                    Console.WriteLine(frog.GetType().Name);
                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                }
                else if(command == "Kitten")
                {
                    Kitten kitten = new Kitten(data[0], int.Parse(data[1]));
                    Console.WriteLine(kitten.GetType().Name);
                    Console.WriteLine(kitten);
                    Console.WriteLine(kitten.ProduceSound());
                }
                else if(command == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(data[0], int.Parse(data[1]));
                    Console.WriteLine(tomcat.GetType().Name);
                    Console.WriteLine(tomcat);
                    Console.WriteLine(tomcat.ProduceSound());
                }


                command = Console.ReadLine();
                if (command == "Beast!")
                {
                    break;
                }
                data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        

        }
    }
}
