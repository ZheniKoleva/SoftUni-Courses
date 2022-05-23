using System;

namespace _04._TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();

            double cheapestPrice = 0;
            double taxiRate = 0;

            if (dayOrNight == "day")
            {
                taxiRate = 0.79; 
            }
            else
            {
                taxiRate = 0.90;
            }
            if (distance < 20)
            {
                cheapestPrice = taxiRate * distance + 0.70;
            }
            else if (distance < 100)
            {
                cheapestPrice = distance * 0.09;
            }
            else
            {
                cheapestPrice = distance * 0.06;
            }
            Console.WriteLine($"{cheapestPrice:f2}");
        }
    }
}
