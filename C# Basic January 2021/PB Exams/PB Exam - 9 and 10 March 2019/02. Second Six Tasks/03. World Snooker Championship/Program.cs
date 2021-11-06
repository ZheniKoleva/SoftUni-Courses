using System;

namespace _03.WorldSnookerChampionship
{
    class Program
    {
        static void Main(string[] args)
        {
            string tournamentStage = Console.ReadLine().ToLower();
            string typeOfTicket = Console.ReadLine().ToLower();
            int ticketCount = int.Parse(Console.ReadLine());
            char pictureYesOrNo = char.Parse(Console.ReadLine().ToLower());

            double ticketPrice = 0.00;
            double totalPrice = 0.00;

            switch (tournamentStage)
            {
                case "quarter final":
                    switch (typeOfTicket)
                    {
                        case "standard":
                            ticketPrice = 55.50;
                            break;

                        case "premium":
                            ticketPrice = 105.20;
                            break;

                        case "vip":
                            ticketPrice = 118.90;
                            break;

                    }
                    break;

                case "semi final":
                    switch (typeOfTicket)
                    {
                        case "standard":
                            ticketPrice = 75.88;
                            break;

                        case "premium":
                            ticketPrice = 125.22;
                            break;

                        case "vip":
                            ticketPrice = 300.40;
                            break;
                           
                    }
                    break;

                case "final":
                    switch (typeOfTicket)
                    {
                        case "standard":
                            ticketPrice = 110.10;
                            break;

                        case "premium":
                            ticketPrice = 160.66;
                            break;

                        case "vip":
                            ticketPrice = 400.00;
                            break;
                           
                    }
                    break;
            }

            totalPrice = ticketPrice * ticketCount;

            switch (pictureYesOrNo)
            {
                case 'y':
                    if (totalPrice > 4000)
                    {
                        totalPrice -= totalPrice * 0.25;
                    }
                    else if (totalPrice > 2500)
                    {
                        totalPrice -= totalPrice * 0.10;
                        totalPrice += ticketCount * 40;
                    }
                    else
                    {
                        totalPrice += ticketCount * 40;
                    }
                    break;

                default:
                    if (totalPrice > 4000)
                    {
                        totalPrice -= totalPrice * 0.25;
                    }
                    else if (totalPrice > 2500)
                    {
                        totalPrice -= totalPrice * 0.10;
                    }
                    break;
            }

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
