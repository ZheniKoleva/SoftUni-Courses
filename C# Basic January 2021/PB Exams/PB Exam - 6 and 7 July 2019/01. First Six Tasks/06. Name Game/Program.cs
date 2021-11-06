using System;

namespace _06.NameGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int pointsMax = int.MinValue;
            string playerPointsMax = string.Empty;

            string playerName = Console.ReadLine();

            while (playerName != "Stop")
            {
                int points = 0;
                for (int index = 0; index < playerName.Length; index++)
                {
                    int n = int.Parse(Console.ReadLine());

                    if (playerName[index] == n)
                    {
                        points += 10;
                    }
                    else
                    {
                        points += 2;
                    }

                    if (points >= pointsMax)
                    {
                        pointsMax = points;
                        playerPointsMax = playerName;
                    }
                }

                playerName = Console.ReadLine();
            }

            Console.WriteLine($"The winner is {playerPointsMax} with {pointsMax} points!");
        }
    }
}
