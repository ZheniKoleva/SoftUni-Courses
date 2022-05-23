using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int productsCount = int.Parse(Console.ReadLine());

            List<string> products = FillList(productsCount);
            PrintList(products);
        }

        private static void PrintList(List<string> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }

        private static List<string> FillList(int productsCount)
        {
            List<string> result = new List<string>(productsCount);

            for (int i = 0; i < productsCount; i++)
            {
                result.Add(Console.ReadLine());
            }

            result.Sort();
            return result;
        }
    }
}
