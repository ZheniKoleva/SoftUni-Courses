using System;

namespace _06.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int ticketsCountsTotal = 0;

            int studentsTickets = 0;
            int standardTickets = 0;
            int kidsTickets = 0;

            while (input != "Finish")
            {
                int freeSeats = int.Parse(Console.ReadLine());                
                string ticketType = Console.ReadLine();

                int movieTicketsCount = 0;

                while (ticketType != "End")
                {
                    switch (ticketType)
                    {
                        case "standard":
                            standardTickets++;
                            break;
                        case "student":
                            studentsTickets++;
                            break;
                        case "kid":
                            kidsTickets++;
                            break;
                    }
                    movieTicketsCount++;
                    ticketsCountsTotal++;

                    if (movieTicketsCount >= freeSeats)
                    {
                        break;
                    }
                   
                    ticketType = Console.ReadLine();
                }

                double percentMovieFull = movieTicketsCount * 100.00 / freeSeats;
                Console.WriteLine($"{input} - {percentMovieFull:f2}% full.");

                input = Console.ReadLine();
            }

            double percentStudents = studentsTickets * 100.00 / ticketsCountsTotal;
            double percentStandard = standardTickets * 100.00 / ticketsCountsTotal;
            double percentKids = kidsTickets * 100.00 / ticketsCountsTotal;

            if (input == "Finish")
            {
                Console.WriteLine($"Total tickets: {ticketsCountsTotal}");
                Console.WriteLine($"{percentStudents:f2}% student tickets.");
                Console.WriteLine($"{percentStandard:f2}% standard tickets.");
                Console.WriteLine($"{percentKids:f2}% kids tickets.");
            }
        }
    }
}
