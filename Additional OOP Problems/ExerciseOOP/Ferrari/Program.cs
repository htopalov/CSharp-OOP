﻿using System;

namespace Ferrari
{
    public class Program
    {
        static void Main(string[] args)
        {
            string driver = Console.ReadLine();
            Ferrari ferrari = new Ferrari(driver);
            Console.WriteLine($"{ferrari.Model}/{ferrari.Brakes()}/{ferrari.GasPedal()}/{ferrari.Driver}");
        }
    }
}
