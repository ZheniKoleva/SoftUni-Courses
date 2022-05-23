using System;

namespace _01.AgencyProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            string companyName = Console.ReadLine();
            int ticketsAdults = int.Parse(Console.ReadLine());
            int ticketsKids = int.Parse(Console.ReadLine());
            double priceAdults = double.Parse(Console.ReadLine());
            double serviceTax = double.Parse(Console.ReadLine());

            double priceKids = priceAdults * 0.30;

            double totalPrice = (priceAdults + serviceTax) * ticketsAdults + (priceKids + serviceTax) * ticketsKids;
            double profit = totalPrice * 0.20;

            Console.WriteLine($"The profit of your agency from {companyName} tickets is {profit:f2} lv.");

        }
    }
}
