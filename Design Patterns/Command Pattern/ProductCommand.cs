using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Pattern
{
    public class ProductCommand : ICommand
    {
        private readonly ProductReceiver product;
        private readonly PriceAction action;
        private readonly int amount;

        public ProductCommand(ProductReceiver product, PriceAction action, int amount)
        {
            this.product = product;
            this.action = action;
            this.amount = amount;
        }
        public void Execute()
        {
            if (action == PriceAction.Increase)
            {
                product.IncreasePrice(amount);
            }
            else
            {
                product.DecreasePrice(amount);
            }
        }
    }
}
