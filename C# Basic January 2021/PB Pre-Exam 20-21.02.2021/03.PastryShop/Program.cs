using System;

namespace _03.PastryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string pastryType = Console.ReadLine().ToLower();
            int pastryOrdered = int.Parse(Console.ReadLine());
            int dayOfTheMonth = int.Parse(Console.ReadLine());

            double pastryPricePerOne = 0.00;

            switch (pastryType)
            {
                case "cake":
                    if (dayOfTheMonth <= 15)
                    {
                        pastryPricePerOne = 24.00;
                    }
                    else if (dayOfTheMonth > 15)
                    {
                        pastryPricePerOne = 28.70;
                    }

                    break;

                case "souffle":
                    if (dayOfTheMonth <= 15)
                    {
                        pastryPricePerOne = 6.66;
                    }
                    else if (dayOfTheMonth > 15)
                    {
                        pastryPricePerOne = 9.80;
                    }

                    break;

                case "baklava":
                    if (dayOfTheMonth <= 15)
                    {
                        pastryPricePerOne = 12.60;
                    }
                    else if (dayOfTheMonth > 15)
                    {
                        pastryPricePerOne = 16.98;
                    }

                    break;
                
            }

            double totalPrice = pastryPricePerOne * pastryOrdered;

            if (dayOfTheMonth <= 22)
            {
                if (totalPrice >= 100 && totalPrice <= 200)
                {
                    totalPrice -= totalPrice * 0.15;
                }
                else if (totalPrice > 200)
                {
                    totalPrice -= totalPrice * 0.25;
                }

                if (dayOfTheMonth <= 15)
                {
                    totalPrice -= totalPrice * 0.10;
                }
            }

            Console.WriteLine($"{totalPrice:f2}");

        }
    }
}
