using System;
using System.Collections.Generic;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();
            
            string line;

            while ((line = Console.ReadLine()) != "Revision")
            {                
                ExtractData(line, out string shop, out string product, out double price);

                FillShopData(shops, shop, product, price);                
            }

            PrindShopData(shops);
        }

        private static void PrindShopData(SortedDictionary<string, Dictionary<string, double>> shops)
        {
            foreach (var (shop, products) in shops)
            {
                Console.WriteLine($"{shop}->");

                foreach (var (product, price) in products)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }

        private static void FillShopData(SortedDictionary<string, Dictionary<string, double>> shops, string shop, string product, double price)
        {
            if (!shops.ContainsKey(shop))
            {
                shops.Add(shop, new Dictionary<string, double>());
            }

            if (!shops[shop].ContainsKey(product))
            {
                shops[shop].Add(product, 0.0);
            }

            shops[shop][product] = price;
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
}
