using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var phone = new SingleGift("Samsung", 500);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            var bigBox = new CompositeGift("Big box", 0);
            var toy1 = new SingleGift("Car", 10);
            var toy2 = new SingleGift("Bear", 12);
            bigBox.Add(toy1);
            bigBox.Add(toy2);
            var smallBox = new CompositeGift("Small box", 0);
            var toy3 = new SingleGift("playstation", 400);
            var toy4 = new SingleGift("sword", 11);
            smallBox.Add(toy3);
            smallBox.Add(toy4);
            bigBox.Add(smallBox);


            Console.WriteLine($"Total price of composite present is: {bigBox.CalculateTotalPrice()}");
        }

    }
}
