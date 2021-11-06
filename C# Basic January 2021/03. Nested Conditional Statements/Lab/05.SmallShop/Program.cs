using System;

namespace _05.SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string item = Console.ReadLine();
            string town = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double priceItem = 0.00;
            double totalPrice = 0.00;

            switch (town)
            {
                case "Sofia":
                    if (item.Equals("coffee"))
                    {
                        priceItem = 0.50;
                    }
                    else if (item.Equals("water"))
                    {
                        priceItem = 0.80;
                    }
                    else if (item.Equals("beer"))
                    {
                        priceItem = 1.20;
                    }
                    else if (item.Equals("sweets"))
                    {
                        priceItem = 1.45;
                    }
                    else if (item.Equals("peanuts"))
                    {
                        priceItem = 1.60;
                    }
                    break;

                case "Plovdiv":
                    if (item.Equals("coffee"))
                    {
                        priceItem = 0.40;
                    }
                    else if (item.Equals("water"))
                    {
                        priceItem = 0.70;
                    }
                    else if (item.Equals("beer"))
                    {
                        priceItem = 1.15;
                    }
                    else if (item.Equals("sweets"))
                    {
                        priceItem = 1.30;
                    }
                    else if (item.Equals("peanuts"))
                    {
                        priceItem = 1.50;
                    }
                    break;

                case "Varna":
                    if (item.Equals("coffee"))
                    {
                        priceItem = 0.45;
                    }
                    else if (item.Equals("water"))
                    {
                        priceItem = 0.70;
                    }
                    else if (item.Equals("beer"))
                    {
                        priceItem = 1.10;
                    }
                    else if (item.Equals("sweets"))
                    {
                        priceItem = 1.35;
                    }
                    else if (item.Equals("peanuts"))
                    {
                        priceItem = 1.55;
                    }
                    break;
                    
            }

            totalPrice = quantity * priceItem;
            Console.WriteLine(totalPrice);
        }
    }
}
