using System;

namespace Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            try
            {
                double result = System.Convert.ToDouble(number);
                Console.WriteLine(result);
            }
            catch(FormatException)
            {
                Console.WriteLine("Format not supported",number);
            }
            catch(OverflowException)
            {
                Console.WriteLine("Number not in range of double", number);
            }
            Console.ReadLine();

        }
    }
}
