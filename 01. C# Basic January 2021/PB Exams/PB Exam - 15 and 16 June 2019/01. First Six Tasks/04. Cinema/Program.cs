using System;

namespace _04.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallSeats = int.Parse(Console.ReadLine());

            const double ticketPrice = 5.00;
            double profits = 0;

            string input = Console.ReadLine();

            while (input != "Movie time!")
            {
                int peopleEntering = int.Parse(input);

                if (hallSeats >= peopleEntering)
                {
                    hallSeats -= peopleEntering;
                    profits += peopleEntering * ticketPrice;
                    if (peopleEntering % 3 == 0)
                    {
                        profits -= 5;
                    }

                }
                else
                {
                    break;

                }

                input = Console.ReadLine();
            }

            if (input == "Movie time!")
            {
                Console.WriteLine($"There are {hallSeats} seats left in the cinema.");
            }
            else
            {
                Console.WriteLine($"The cinema is full.");
            }

            Console.WriteLine($"Cinema income - {profits} lv.");
        }
    }
}
