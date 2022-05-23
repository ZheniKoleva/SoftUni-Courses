using System;

namespace _02.FootballResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstMatch = Console.ReadLine();
            string secondMatch = Console.ReadLine();
            string thirdMatch = Console.ReadLine();

            int wons = 0;
            int losts = 0;
            int drawns = 0;

            if (firstMatch[0] > firstMatch[2])
            {
                wons++;
            }
            else if (firstMatch[0] < firstMatch[2])
            {
                losts++;
            }
            else if (firstMatch[0] == firstMatch[2])
            {
                drawns++;
            }

            if (secondMatch[0] > secondMatch[2])
            {
                wons++;
            }
            else if (secondMatch[0] < secondMatch[2])
            {
                losts++;
            }
            else if (secondMatch[0] == secondMatch[2])
            {
                drawns++;
            }

            if (thirdMatch[0] > thirdMatch[2])
            {
                wons++;
            }
            else if (thirdMatch[0] < thirdMatch[2])
            {
                losts++;
            }
            else if (thirdMatch[0] == thirdMatch[2])
            {
                drawns++;
            }

            Console.WriteLine($"Team won {wons} games.");
            Console.WriteLine($"Team lost {losts} games.");
            Console.WriteLine($"Drawn games: {drawns}");
        }
    }
}
