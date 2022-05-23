using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            //List<Product> products = new List<Product>();

            string line = Console.ReadLine();

            while (line != "buy")
            {
                string[] productData = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                FillUpProducts(products, productData);

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, products.Values));
        }

        private static void FillUpProducts(Dictionary<string, Product> products, string[] productData)
        {
            string productName = productData[0];
            double price = double.Parse(productData[1]);
            int quantity = int.Parse(productData[2]);

            if (!products.ContainsKey(productName))
            {
                //products.Add(new Product(productName, price, quantity));
                products.Add(productName, new Product(productName, price, quantity));
            }
            else
            {
                products[productName].Quantity += quantity;
                products[productName].Price = price;
            }
        }
    }

    //class Product
    //{
    //    public Product(string name, double price, int quantity)
    //    {
    //        this.Name = name;
    //        this.Price = price;
    //        this.Quantity = quantity;
    //    }
    //    public string Name { get; private set; }

    //    public double Price { get; set; }

    //    public int Quantity { get; set; }

    //    private double GetTotalPrice()
    //    {
    //        return Price * Quantity;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{Name} -> {GetTotalPrice():f2}";
    //    }
    //}
}
