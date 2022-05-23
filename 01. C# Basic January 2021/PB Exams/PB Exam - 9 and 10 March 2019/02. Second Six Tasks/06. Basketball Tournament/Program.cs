using System;

namespace _06.BasketballTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int matchesAll = 0;
            int matchesWin = 0;
            int mathesLost = 0;

            while (input != "End of tournaments")
            {
                int tournamentGamesCount = int.Parse(Console.ReadLine());
                matchesAll += tournamentGamesCount;

                for (int gameNumber = 1; gameNumber <= tournamentGamesCount; gameNumber++)
                {
                    int gamePointsTeam1 = int.Parse(Console.ReadLine());
                    int gamePointsTeam2 = int.Parse(Console.ReadLine());

                    int pointsDifference = 0;

                    if (gamePointsTeam1 > gamePointsTeam2)
                    {
                        matchesWin++;
                        pointsDifference = gamePointsTeam1 - gamePointsTeam2;
                        Console.WriteLine($"Game {gameNumber} of tournament {input}: win with {pointsDifference} points.");
                    }
                    else
                    {
                        mathesLost++;
                        pointsDifference = gamePointsTeam2 - gamePointsTeam1;
                        Console.WriteLine($"Game {gameNumber} of tournament {input}: lost with {pointsDifference} points.");
                    }

                }

                input = Console.ReadLine();
            }

            double percentWins = matchesWin * 100.00 / matchesAll;
            double percentLosts = mathesLost * 100.00 / matchesAll;

            if (input == "End of tournaments")
            {
                Console.WriteLine($"{percentWins:f2}% matches win");
                Console.WriteLine($"{percentLosts:f2}% matches lost");
            }
        }
    }
}
