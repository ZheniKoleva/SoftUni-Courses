using System;

namespace _03.NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowersType = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            const double priceRoses = 5.00;
            const double priceDahlias = 3.80;
            const double priceTulips = 2.80;
            const double priceNarcissus = 3.00;
            const double priceGladiolus = 2.50;
            double totalPrice = 0.00;

            switch (flowersType)
            {    
                case "Roses":
                    totalPrice = flowerCount * priceRoses;
                    if (flowerCount > 80)
                    {
                        totalPrice -= totalPrice * 0.10;
                    }
                    break;

                case "Dahlias":
                    totalPrice = flowerCount * priceDahlias;
                    if (flowerCount > 90)
                    {
                        totalPrice -= totalPrice * 0.15;
                    }
                    break;

                case "Tulips":
                    totalPrice = flowerCount * priceTulips;
                    if (flowerCount > 80)
                    {
                        totalPrice -= totalPrice * 0.15;
                    }
                    break;

                case "Narcissus":
                    totalPrice = flowerCount * priceNarcissus;
                    if (flowerCount < 120)
                    {
                        totalPrice += totalPrice * 0.15;
                    }
                    break;

                case "Gladiolus":
                    totalPrice = flowerCount * priceGladiolus;
                    if (flowerCount < 80)
                    {
                        totalPrice += totalPrice * 0.20;
                    }
                    break;

            }

            if (totalPrice <= budget)
            {
                double moneyLeft = budget - totalPrice;
                Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowersType} and " +
                    $"{moneyLeft:f2} leva left.");
            }
            else
            {
                double moneyNeed = totalPrice - budget;
                Console.WriteLine($"Not enough money, you need {moneyNeed:f2} leva more.");
            }

        }
    }
}
