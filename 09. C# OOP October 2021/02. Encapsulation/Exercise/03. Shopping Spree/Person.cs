namespace _03.ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;

        private decimal money;

        private readonly List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag => this.bag.AsReadOnly();

        public string BuyProduct(Product product)
        {
            if (this.money < product.Cost)
            {
                return $"{this.name} can't afford {product.Name}";
            }

            this.money -= product.Cost;
            this.bag.Add(product);

            return $"{this.name} bought {product.Name}";
        }

        public override string ToString()
            => $"{this.name} - {(this.bag.Count == 0 ? "Nothing bought" : string.Join(", ", this.bag))}";  
    }
}
