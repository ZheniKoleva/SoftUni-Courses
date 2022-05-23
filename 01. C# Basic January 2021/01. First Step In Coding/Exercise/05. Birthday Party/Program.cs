using System;

namespace _05._BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());

            const double cakePercent = 0.20;
            const double drinksPercent = 0.55;
          
            double cakePrice = rent * cakePercent;
            double drinksPrice = cakePrice * drinksPercent;
            double animator = rent / 3;

            double totalPrice = rent + cakePrice + drinksPrice + animator;
            Console.WriteLine(totalPrice);
        }
    }
}
