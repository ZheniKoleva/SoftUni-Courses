using System;

namespace _05.PCGameShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int gamesSold = int.Parse(Console.ReadLine());

            int heartstoneCount = 0;
            int forniteCount = 0;
            int overwatchCount = 0;
            int othersGamesCount = 0;

            for (int i = 0; i < gamesSold; i++)
            {
                string gameName = Console.ReadLine();

                switch (gameName)
                {
                    case "Hearthstone":
                        heartstoneCount++;
                        break;
                    case "Fornite":
                        forniteCount++;
                        break;
                    case "Overwatch":
                        overwatchCount++;
                        break;
                    default:
                        othersGamesCount++;
                        break;

                }
                
            }

            double percentHeartstone = (1.0 * heartstoneCount) / gamesSold * 100;
            double percentFornite = (1.0 * forniteCount) / gamesSold * 100;
            double percentOverwatch = (1.0 * overwatchCount) / gamesSold * 100;
            double percentOthers = (1.0 * othersGamesCount) / gamesSold * 100;

            Console.WriteLine($"Hearthstone - {percentHeartstone:f2}%");
            Console.WriteLine($"Fornite - {percentFornite:f2}%");
            Console.WriteLine($"Overwatch - {percentOverwatch:f2}%");
            Console.WriteLine($"Others - {percentOthers:f2}%");
        }
    }
}
