using System;
using System.Collections.Generic;
using System.Text;

namespace _06.StoreBoxes
{
    public class Item
    {
        private string name;

        private double price;

        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

    }
}
