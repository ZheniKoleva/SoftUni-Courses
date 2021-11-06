using System;

namespace _06.EasterDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int clientsCount = int.Parse(Console.ReadLine());

            const double basketPrice = 1.50;
            const double wreathPrice = 3.80;
            const double chocolateBunnyPrice = 7.00;

            double totalSumAll = 0;

            for (int clients = 0; clients < clientsCount; clients++)
            {
                double totalSumPerClient = 0;
                int itemsBought = 0;

                string purchace = Console.ReadLine();
                while (purchace != "Finish")
                {
                    switch (purchace)
                    {
                        case "basket":
                            totalSumPerClient += basketPrice;
                            break;

                        case "wreath":
                            totalSumPerClient += wreathPrice;
                            break;

                        case "chocolate bunny":
                            totalSumPerClient += chocolateBunnyPrice;
                                break;

                    }
                    itemsBought++;                    
                    purchace = Console.ReadLine();
                }

                if (itemsBought % 2 == 0)
                {
                    totalSumPerClient -= totalSumPerClient * 0.20;
                }

                Console.WriteLine($"You purchased {itemsBought} items for {totalSumPerClient:f2} leva.");
                totalSumAll += totalSumPerClient;
            }

            double averageSum = totalSumAll / clientsCount;
            Console.WriteLine($"Average bill per client is: {averageSum:f2} leva.");
        }
    }
}
