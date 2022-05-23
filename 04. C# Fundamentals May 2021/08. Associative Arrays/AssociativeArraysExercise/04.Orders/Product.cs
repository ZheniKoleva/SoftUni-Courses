using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Orders
{
    class Product
    {    
        public Product(string name, double price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }
        public string Name { get; private set; }

        public double Price { get; set; }

        public int Quantity {get; set; }

        private double GetTotalPrice() 
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            return $"{Name} -> {GetTotalPrice():f2}";
        }
    }
}
