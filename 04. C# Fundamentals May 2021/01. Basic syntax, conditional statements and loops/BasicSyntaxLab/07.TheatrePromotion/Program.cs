using System;

namespace _07.TheatrePromotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string period = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            int ticketPrice = 0;

            switch (period)
            {
                case "Weekday":
                    if ((age >= 0 && age <= 18)
                        || (age > 64 && age <= 122))
                    {
                        ticketPrice = 12;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        ticketPrice = 18;
                    }
                    break;

                case "Weekend":
                    if ((age >= 0 && age <= 18)
                        || (age > 64 && age <= 122))
                    {
                        ticketPrice = 15;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        ticketPrice = 20;
                    }
                    break;

                case "Holiday":
                    if (age >= 0 && age <= 18)                       
                    {
                        ticketPrice = 5;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        ticketPrice = 12;
                    }
                    else if (age > 64 && age <= 122)
                    {
                        ticketPrice = 10;
                    }
                    break;

            }

            if (ticketPrice != 0)
            {
                Console.WriteLine($"{ticketPrice}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }

        }
    }
}
