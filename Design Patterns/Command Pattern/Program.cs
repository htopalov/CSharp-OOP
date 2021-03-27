using System;

namespace Command_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var modifyPrice = new ModifyPrice();
            var product = new ProductReceiver("Phone", 200);
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 34));

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 12));

            Console.WriteLine(product);
        }

        private static void Execute(ProductReceiver product, ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
