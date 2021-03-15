﻿using P03._ShoppingCart;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03._ShoppingCart_Before.Contracts
{
    public interface IPriceRule
    {
        decimal PriceCalculator(OrderItem item);
        bool IsMatch(OrderItem item);
    }
}
