using Mocking_and_Test_Driven_Development_Lab.Contracs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mocking_and_Test_Driven_Development_Lab
{
    public class Product : IProduct
    {
        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }
        public string Label { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
    }
}
