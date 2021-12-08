using System;
using System.Linq;
using System.Collections.Generic;

using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private const int Default_Capacity = 100;

        private int capacity = Default_Capacity;

        private readonly IList<Item> items;

        protected Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity 
        { 
            get => capacity; 
            set => capacity = value; 
        }

        public int Load => items.Any() ? items.Sum(x => x.Weight) : 0;

        public IReadOnlyCollection<Item> Items => (IReadOnlyCollection<Item>)items;

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
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

            Item itemToRemove = items.FirstOrDefault(x => x.GetType().Name == name);

            if (itemToRemove == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            items.Remove(itemToRemove);

            return itemToRemove;
        }
    }
}
