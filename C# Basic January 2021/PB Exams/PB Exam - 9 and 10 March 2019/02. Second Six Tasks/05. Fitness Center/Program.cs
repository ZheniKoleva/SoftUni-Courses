using System;

namespace _05.FitnessCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            int visitorsCount = int.Parse(Console.ReadLine());

            int countBack = 0;
            int countChest = 0;
            int countLegs = 0;
            int countAbs = 0;
            int countProteinShake = 0;
            int countProteinBar = 0;

            for (int i = 1; i <= visitorsCount; i++)
            {
                string activity = Console.ReadLine().ToLower();

                switch (activity)
                {
                    case "back":
                        countBack++;
                        break;
                    case "chest":
                        countChest++;
                        break;
                    case "legs":
                        countLegs++;
                        break;
                    case "abs":
                        countAbs++;
                        break;
                    case "protein shake":
                        countProteinShake++;
                        break;
                    case "protein bar":
                        countProteinBar++;
                        break;
                }

            }

            double percentWorkOut = (countBack + countChest + countLegs + countAbs) * 100.00 / visitorsCount;
            double percentBuyingProtein = (countProteinShake + countProteinBar) * 100.00 / visitorsCount;

            Console.WriteLine($"{countBack} - back");
            Console.WriteLine($"{countChest} - chest");
            Console.WriteLine($"{countLegs} - legs");
            Console.WriteLine($"{countAbs} - abs");
            Console.WriteLine($"{countProteinShake} - protein shake");
            Console.WriteLine($"{countProteinBar} - protein bar");
            Console.WriteLine($"{percentWorkOut:f2}% - work out");
            Console.WriteLine($"{percentBuyingProtein:f2}% - protein");           
        }
    }
}
