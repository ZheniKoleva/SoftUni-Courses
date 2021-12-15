using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ProductShop2
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Shop> shops = new SortedDictionary<string, Shop>();

            string line;

            while ((line = Console.ReadLine()) != "Revision")
            {
                ExtractData(line, out string shop, out string product, out double price);

                FillShopData(shops, shop, product, price);
            }

            PrindShopData(shops);
        }

        private static void PrindShopData(SortedDictionary<string, Shop> shops)
        {
            foreach (var shopProducts in shops.Values)
            {
                Console.WriteLine(string.Join(Environment.NewLine, shopProducts));               
            }
        }

        private static void FillShopData(SortedDictionary<string, Shop> shops, string shop, string product, double price)
        {
            if (!shops.ContainsKey(shop))
            {
                shops.Add(shop, new Shop(shop));
            }

            shops[shop].Products.Add(new Product(product, price));
        }

        private static void ExtractData(string line, out string shop, out string product, out double price)
        {
            string[] shopData = line
                                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            shop = shopData[0];
            product = shopData[1];
            price = double.Parse(shopData[2]);
        }
    }

    public class Shop
    {
        public Shop(string name)
        {
            Name = name;
            Products = new List<Product>();
        }

        public string Name{ get;}

        public List<Product> Products { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{Name}->");
            output.Append(string.Join(Environment.NewLine, Products));

            return output.ToString();
        }
    }

    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
        
        public string Name { get;}

        public double Price { get; set; }

        public override string ToString()
        {
            return $"Product: {Name}, Price: {Price}";
        }
    }
}
