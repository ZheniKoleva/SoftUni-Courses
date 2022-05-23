using System;

namespace _03.FilmPremiere
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine().ToLower();
            string moviePacket = Console.ReadLine().ToLower();
            int ticketsCount = int.Parse(Console.ReadLine());

            double ticketPrice = 0.00;

            switch (movieName)
            {
                case "john wick":
                    switch (moviePacket)
                    {
                        case "drink":
                            ticketPrice = 12.00;
                            break;
                        case "popcorn":
                            ticketPrice = 15.00;
                            break;
                        case "menu":
                            ticketPrice = 19.00;
                            break;                        
                    }
                    break;

                case "star wars":
                    switch (moviePacket)
                    {
                        case "drink":
                            ticketPrice = 18.00;
                            break;
                        case "popcorn":
                            ticketPrice = 25.00;
                            break;
                        case "menu":
                            ticketPrice = 30.00;
                            break;
                    }
                    break;

                case "jumanji":
                    switch (moviePacket)
                    {
                        case "drink":
                            ticketPrice = 9.00;
                            break;
                        case "popcorn":
                            ticketPrice = 11.00;
                            break;
                        case "menu":
                            ticketPrice = 14.00;
                            break;
                    }
                    break;
            }

            double totalPrice = ticketPrice * ticketsCount;

            if (movieName == "star wars" && ticketsCount >= 4) 
            {
                totalPrice -= totalPrice * 0.30;
            }
            else if (movieName == "jumanji" && ticketsCount == 2)
            {
                totalPrice -= totalPrice * 0.15;
            }

            Console.WriteLine($"Your bill is {totalPrice:f2} leva.");
        }
    }
}
