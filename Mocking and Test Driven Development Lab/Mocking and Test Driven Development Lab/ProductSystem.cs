using Mocking_and_Test_Driven_Development_Lab.Contracs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mocking_and_Test_Driven_Development_Lab
{
    public class ProductSystem : ISystem, IEnumerable<IProduct>
    {
        private readonly IList<IProduct> products;
        public ProductSystem(IList<IProduct> repo)
        {
            products = repo;
        }

        public int Count => products.Count;

        public void Add(IProduct product)
        {
            if (this.Contains(product))
            {
                throw new ArgumentException("Product already added!");
            }
            products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            return products.Any(p => p.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index > products.Count)
            {
                throw new IndexOutOfRangeException("Index does not exist. Index must be in range of Max products count.");
            }
            return products[index];
        }

        public IList<IProduct> FindAllByPrice(decimal price)
        {
            return products.Where(p => p.Price == price).ToList();
        }

        public IList<IProduct> FindAllByQuantity(int quantity)
        {
            return products.Where(p => p.Quantity == quantity).ToList();
        }

        public IList<IProduct> FindAllInPriceRange(decimal lowerEndPrice, decimal higherEndPrice)
        {
            var list =  products.Where(p => p.Price >= lowerEndPrice && p.Price <= higherEndPrice)
                           .OrderByDescending(p => p.Price)
                           .ToList();
            return list;
        }

        public IProduct FindByLabel(string label)
        {
            var product = products.FirstOrDefault(p => p.Label == label);
            if (product == null)
            {
                throw new ArgumentException("No such product!");
            }
            return product;
        }

        public IProduct FindMostExpensiveProducts()
        {
            var list = products.OrderByDescending(p => p.Price).ToList();
            return list[0];

        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var product in products)
            {
                yield return product;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IProduct this[int index]
        {
            get
            {
                return products[index];
            }
            set
            {
                products[index] = value;
            }
        }
    }
}
