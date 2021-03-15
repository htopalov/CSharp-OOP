using System;

namespace P01._Square_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle();
            rec.Width = 10;
            rec.Height = 20;
            Console.WriteLine(rec.Area);
            Square square = new Square();
            square.Side = 15;
            Console.WriteLine(square.Area);
        }
    }
}
