using System;

namespace _01._MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine().ToLower();
            int peopleNumber = int.Parse(Console.ReadLine());

            double ticketPrice = 0.0;
            double transportExpenses = 0.0;
            double sumForTickets = 0.0;            

            if (peopleNumber >= 1 && peopleNumber <= 4)
            {
                transportExpenses = budget * 0.75;
            }
            else if (peopleNumber >= 5 && peopleNumber <= 9)
            {
                transportExpenses = budget * 0.60;
            }
            else if (peopleNumber >= 10 && peopleNumber <= 24)
            {
                transportExpenses = budget * 0.50;
            }
            else if (peopleNumber >= 25 && peopleNumber <= 49)
            {
                transportExpenses = budget * 0.40;
            }
            else
            {
                transportExpenses = budget * 0.25;
            }

            sumForTickets = budget - transportExpenses;

            switch (category)
            {
                case "vip":
                    ticketPrice = 499.99;
                    break;
                case "normal":
                    ticketPrice = 249.99;
                    break;
            }

            double needSum = ticketPrice * peopleNumber;

            if (sumForTickets >= needSum)
            {
                Console.WriteLine($"Yes! You have {(sumForTickets - needSum):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(needSum - sumForTickets):f2} leva.");
            }
        }
    }
}
