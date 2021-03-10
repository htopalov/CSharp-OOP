using System;

namespace CustomException
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = new Student("Gin4o", "Ginchev", 23, "gin4o@mail.bg");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex2)
            {
                Console.WriteLine(ex2.Message);
            }
            catch(InvalidPersonNameException ex3)
            {
                Console.WriteLine(ex3.Message);
            }
        }
    }
}
