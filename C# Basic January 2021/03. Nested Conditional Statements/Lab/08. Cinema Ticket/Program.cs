using System;

namespace _08.CinemaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayOfWeek = Console.ReadLine().ToLower();

            int ticketPrice = 0;

            switch (dayOfWeek)
            {
                case "monday":
                case "tuesday":
                case "friday":
                    ticketPrice = 12;
                    break;

                case "wednesday":
                case "thursday":
                    ticketPrice = 14;
                    break;
                
                case "saturday":
                case "sunday":
                    ticketPrice = 16;
                    break;                
            }

            Console.WriteLine(ticketPrice);
        }
    }
}
