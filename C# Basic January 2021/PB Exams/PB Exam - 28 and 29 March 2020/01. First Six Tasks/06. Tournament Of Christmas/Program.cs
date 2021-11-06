using System;

namespace _06.TournamentOfChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournamentDaysCount = int.Parse(Console.ReadLine());

            double moneyWonTotal = 0.00;
            int daysWon = 0;

            for (int day = 1; day <= tournamentDaysCount; day++)
            {
                double moneyWonPerDay = 0;
                int gamesWon = 0;
                int gamesLost = 0;

                string sport = Console.ReadLine();

                while (sport != "Finish")
                {
                    string result = Console.ReadLine();

                    switch (result)
                    {
                        case "win":
                            moneyWonPerDay += 20;
                            gamesWon++;
                            break;

                        case "lose":
                            gamesLost++;
                            break;
                    }

                    sport = Console.ReadLine();
                }

                if (gamesWon > gamesLost)
                {
                    moneyWonPerDay += moneyWonPerDay * 0.10;
                    daysWon++;
                }

                moneyWonTotal += moneyWonPerDay;

            }

            if (daysWon > tournamentDaysCount - daysWon)
            {
                moneyWonTotal += moneyWonTotal * 0.20;
                Console.WriteLine($"You won the tournament! Total raised money: {moneyWonTotal:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {moneyWonTotal:f2}");
            }

        }
    }
}
