using System;

namespace _07.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();

            int ticketBought = 0;
            int studentCount = 0;
            int standardCount = 0;
            int kidCount = 0;

            while (movieName != "Finish")
            {
                int capasity = int.Parse(Console.ReadLine());
                string ticketType = Console.ReadLine();

                int seatsTaken = 0;

                while (ticketType != "End")
                {
                    ticketBought++;
                    seatsTaken++;

                    switch (ticketType)
                    {
                        case "student":                            
                            studentCount++;
                            break;

                        case "standard":                           
                            standardCount++;
                            break;

                        case "kid":                           
                            kidCount++;
                            break;                        
                    }

                    if (seatsTaken == capasity)
                    {
                        break;
                    }

                    ticketType = Console.ReadLine();

                }

                double percentSeatsTaken = (seatsTaken * 100.00) / capasity;
                Console.WriteLine($"{movieName} - {percentSeatsTaken:f2}% full.");

                movieName = Console.ReadLine();
            }

            double persentStudent = (studentCount * 100.00) / ticketBought;
            double persentStandard = (standardCount * 100.00) / ticketBought;
            double persentKid = (kidCount * 100.00) / ticketBought;

            Console.WriteLine($"Total tickets: {ticketBought}");
            Console.WriteLine($"{persentStudent:f2}% student tickets.");
            Console.WriteLine($"{persentStandard:f2}% standard tickets.");
            Console.WriteLine($"{persentKid:f2}% kids tickets.");
        }
    }
}
