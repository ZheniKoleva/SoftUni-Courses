using System;

namespace _02.EasterParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int guestsNumber = int.Parse(Console.ReadLine());
            double pricePerPerson = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double cakePrice = budget * 0.10;            

            if (guestsNumber >= 10 && guestsNumber <= 15)
            {
                pricePerPerson *= 0.85;
            }
            else if (guestsNumber > 15 && guestsNumber <= 20)
            {
                pricePerPerson *= 0.80;
            }
            else if (guestsNumber > 20)
            {
                pricePerPerson *= 0.75;
            }

            double totalPrice = cakePrice + (guestsNumber * pricePerPerson);

            if (budget >= totalPrice)
            {
                double moneyLeft = budget - totalPrice;
                Console.WriteLine($"It is party time! {moneyLeft:f2} leva left.");
            }
            else
            {
                double moneyNeed = totalPrice - budget;
                Console.WriteLine($"No party! {moneyNeed:f2} leva needed.");
            }
        }
    }
}
