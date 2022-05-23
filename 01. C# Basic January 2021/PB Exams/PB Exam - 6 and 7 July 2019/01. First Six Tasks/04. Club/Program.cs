using System;

namespace _04.Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double profitWished = double.Parse(Console.ReadLine());

            bool flagAchieved = false;
            double profitPerNight = 0.00;
            string cocktailName = Console.ReadLine();

            while (cocktailName != "Party!")
            {
                int cocktailsCount = int.Parse(Console.ReadLine());                
                int cocktailPrice = cocktailName.Length;
                double orderPrice = cocktailsCount * cocktailPrice;

                if (orderPrice % 2 != 0)
                {
                    orderPrice -= orderPrice * 0.25;
                }

                profitPerNight += orderPrice;

                if (profitPerNight >= profitWished)
                {
                    flagAchieved = true;                    
                    break;
                }
                cocktailName = Console.ReadLine();
            }

            if (flagAchieved)
            {
                Console.WriteLine("Target acquired.");                
            }
            else
            {
                Console.WriteLine($"We need {(profitWished - profitPerNight):f2} leva more.");
            }

            Console.WriteLine($"Club income - {profitPerNight:f2} leva.");
        }
    }
}
