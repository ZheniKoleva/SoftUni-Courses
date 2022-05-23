using System;

namespace _02.ReportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetSum = int.Parse(Console.ReadLine());

            int sumCollect = 0;
            int InCashOrByCardCounter = 0;
            int paidInCash = 0;
            int paidByCard = 0;
            int salesInCash = 0;
            int salesByCard = 0;

            bool isReached = false;

            while (!isReached)
            {                
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                int money = int.Parse(input);                

                if (InCashOrByCardCounter == 0)
                {
                    InCashOrByCardCounter = 1;
                    if (money > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        sumCollect += money;
                        paidInCash += money;
                        salesInCash++;
                        Console.WriteLine("Product sold!");                        
                    }                    
                    
                }
                else
                {
                    InCashOrByCardCounter = 0;
                    if (money < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        sumCollect += money;
                        paidByCard += money;
                        salesByCard++;
                        Console.WriteLine("Product sold!");
                    }

                }

                if (sumCollect >= targetSum)
                {
                    isReached = true;
                }

            }

            if (isReached)
            {
                Console.WriteLine($"Average CS: {(paidInCash * 1.0) / salesInCash:f2}");
                Console.WriteLine($"Average CC: {(paidByCard * 1.0) / salesByCard:f2}");
            }
            else
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }
        }
    }
}
