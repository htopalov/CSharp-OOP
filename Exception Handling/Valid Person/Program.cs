using System;

namespace Valid_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person pesho = new Person("Pesho", "Peshev", 24);
                Person noName = new Person(string.Empty, "Goshev", 31);
                Person negativeAge = new Person("Ivan", "Ivanov", -12);
                Person tooOld = new Person("Boncho", "Bonchev", 123);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(IndexOutOfRangeException ex2)
            {
                Console.WriteLine(ex2.Message);
            }
        }
    }
}
