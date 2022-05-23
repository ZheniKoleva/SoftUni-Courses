using System;

namespace _03.OscarsWeekInCinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            string hallType = Console.ReadLine();
            int ticketsBought = int.Parse(Console.ReadLine());

            double ticketPrice = 0.00;
            double totalPrice = 0.00;

            switch (hallType)
            {
                case "normal":
                    switch (movieName)
                    {
                        case "A Star Is Born":
                            ticketPrice = 7.50;
                            break;
                        case "Bohemian Rhapsody":
                            ticketPrice = 7.35;
                            break;
                        case "Green Book":
                            ticketPrice = 8.15;
                            break;
                        case "The Favourite":
                            ticketPrice = 8.75;
                            break;
                    }
                    break;

                case "luxury":
                    switch (movieName)
                    {
                        case "A Star Is Born":
                            ticketPrice = 10.50;
                            break;
                        case "Bohemian Rhapsody":
                            ticketPrice = 9.45;
                            break;
                        case "Green Book":
                            ticketPrice = 10.25;
                            break;
                        case "The Favourite":
                            ticketPrice = 11.55;
                            break;
                    }
                    break;

                case "ultra luxury":
                    switch (movieName)
                    {
                        case "A Star Is Born":
                            ticketPrice = 13.50;
                            break;
                        case "Bohemian Rhapsody":
                            ticketPrice = 12.75;
                            break;
                        case "Green Book":
                            ticketPrice = 13.25;
                            break;
                        case "The Favourite":
                            ticketPrice = 13.95;
                            break;
                    }
                    break;                   
            }

            totalPrice = ticketPrice * ticketsBought;

            Console.WriteLine($"{movieName} -> {totalPrice:f2} lv.");
        }
    }
}
