using System;

namespace _01.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfProjection = Console.ReadLine().ToLower();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            int seats = rows * columns;
            double ticketPrice = 0.00;
            
            switch (typeOfProjection)
            {
                case "premiere":
                    ticketPrice = 12.00;
                    break;
                case "normal":
                    ticketPrice = 7.50;
                    break;
                case "discount":
                    ticketPrice = 5.00;
                    break;
            }

            Console.WriteLine($"{(seats * ticketPrice):f2}");
        }
    }
}
