﻿using P03._ShoppingCart;
using P03._ShoppingCart_Before.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03._ShoppingCart_Before.Rules
{
    public class SpecialRule : IPriceRule
    {
        public bool IsMatch(OrderItem item)
        {
            return item.Sku.StartsWith("SPECIAL");
        }

        public decimal PriceCalculator(OrderItem item)
        {
            decimal price = 0;
            price += item.Price * .4m;
            decimal setsOfThree = item.Price / 3;
            price -= setsOfThree * .2m;
            return price;
        }
    }
}
