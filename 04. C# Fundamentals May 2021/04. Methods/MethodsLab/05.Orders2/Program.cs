using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            Console.WriteLine(GetTotalSum(product, quantity));
        }

        private static string GetTotalSum(string product, int quantity)
        {
            double price = 0.0;

            switch (product)
            {
                case "coffee":
                    price = 1.50;
                    break;

                case "water":
                    price = 1.00;
                    break;

                case "coke":
                    price = 1.40;
                    break;

                case "snacks":
                    price = 2.00;
                    break;
            }

            price *= quantity;
            
            return $"{price:f2}";            
        }
    }
}

