using System;

namespace _05.FootballTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string footballTeamName = Console.ReadLine();
            int gamesPlayed = int.Parse(Console.ReadLine());

            int winsCount = 0;
            int drawnCount = 0;
            int lostsCounts = 0;
            int points = 0;

            for (int game = 1; game <= gamesPlayed; game++)
            {
                char result = char.Parse(Console.ReadLine());

                switch (result)
                {
                    case 'W':
                        winsCount++;
                        points += 3;
                        break;
                    case 'D':
                        drawnCount++;
                        points += 1;
                        break;
                    case 'L':
                        lostsCounts++;
                        break;
                    
                }

            }           

            if (gamesPlayed == 0)
            {
                Console.WriteLine($"{footballTeamName} hasn't played any games during this season.");
            }
            else
            {
                double percentWins = (1.0 * winsCount) / gamesPlayed * 100;
                Console.WriteLine($"{footballTeamName} has won {points} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {winsCount}");
                Console.WriteLine($"## D: {drawnCount}");
                Console.WriteLine($"## L: {lostsCounts}");
                Console.WriteLine($"Win rate: {percentWins:f2}%");
            }
            
        }
    }
}
