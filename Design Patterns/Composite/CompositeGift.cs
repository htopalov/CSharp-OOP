using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;

        public CompositeGift(string name, int price) 
            : base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public override int CalculateTotalPrice()
        {
            int totalPrice = 0;
            Console.WriteLine($"{this.name} contains the following products with prices:");
            foreach (var gift in gifts)
            {
                totalPrice += gift.CalculateTotalPrice();
            }
            return totalPrice;
        }
        public void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }
        public void Remove(GiftBase gift)
        {
            gifts.Remove(gift);
        }
    }
}
