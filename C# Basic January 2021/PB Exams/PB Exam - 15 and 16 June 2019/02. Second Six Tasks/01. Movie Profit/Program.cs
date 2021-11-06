using System;

namespace _01.MovieProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            int daysCount = int.Parse(Console.ReadLine());
            int ticketsCount = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());
            int percentForCinema = int.Parse(Console.ReadLine());

            double profit = daysCount * ticketsCount * ticketPrice;
            profit -= profit * percentForCinema / 100;

            Console.WriteLine($"The profit from the movie {movieName} is {profit:f2} lv.");
        }
    }
}
