using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> items;
        private int capacity;


        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }


        public int Capacity
        {
            get => this.capacity;

            set
            {
                if (value <= 100)
                {
                    this.capacity = value;
                }

            }
        }

        public int Load
        {
            get
            {
                return this.Items.Sum(x => x.Weight);
            }
        }

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            if (!this.items.Any(i => i.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            Item item = items.FirstOrDefault(x => x.GetType().Name == name);
            items.Remove(item);

            return item;
        }
    }
}
