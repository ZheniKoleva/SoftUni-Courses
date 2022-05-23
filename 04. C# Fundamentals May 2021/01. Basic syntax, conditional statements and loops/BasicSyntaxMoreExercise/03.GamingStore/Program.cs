using System;
using System.Collections.Generic;

namespace _03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> gamesList = new Dictionary<string, double>();
            gamesList["OutFall 4"] = 39.99;
            gamesList["CS: OG"] = 15.99;
            gamesList["Zplinter Zell"] = 19.99;
            gamesList["Honored 2"] = 59.99;
            gamesList["RoverWatch"] = 29.99;
            gamesList["RoverWatch Origins Edition"] = 39.99;

            double budget = double.Parse(Console.ReadLine());
            double moneySpend = 0.0;
            bool isOutOfMoney = false;

            string gameName = Console.ReadLine();

            while (gameName != "Game Time")
            {
                if (!gamesList.ContainsKey(gameName))
                {
                    Console.WriteLine("Not found");
                    gameName = Console.ReadLine();
                    continue;
                }

                if (budget >= gamesList[gameName])
                {
                    budget -= gamesList[gameName];
                    Console.WriteLine($"Bought {gameName}");
                    moneySpend += gamesList[gameName];
                }
                else if (budget < gamesList[gameName])
                {
                    Console.WriteLine("Too Expensive");
                }

                if (budget == 0)
                {
                    isOutOfMoney = true;
                    break;
                }
               
                gameName = Console.ReadLine();
            }

            if (isOutOfMoney)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${moneySpend:f2}. Remaining: ${budget:f2}");
            }
        }
    }
}
