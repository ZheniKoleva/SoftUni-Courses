using System;

namespace _01.Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int detergentCount = int.Parse(Console.ReadLine());                      

            int detergentAmount = detergentCount * 750;
            const int amountForPlate = 5;
            const int amountForPot = 15;

            int platesWashed = 0;
            int potsWashed = 0;
            int counter = 0;       
           
            bool isEnough = true;

            while (isEnough)
            {
                string dishes = Console.ReadLine();
                if (dishes == "End")
                {
                    break;
                }

                int dishesForWash = int.Parse(dishes);
                counter++;
                if (counter == 3)
                {
                    counter = 0;
                    potsWashed += dishesForWash;
                    detergentAmount -= dishesForWash * amountForPot;
                }
                else
                {
                    platesWashed += dishesForWash;
                    detergentAmount -= dishesForWash * amountForPlate;
                }

                if (detergentAmount < 0)
                {
                    isEnough = false;
                }

            }

            if (detergentAmount >= 0)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{platesWashed} dishes and {potsWashed} pots were washed.");
                Console.WriteLine($"Leftover detergent {detergentAmount} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(detergentAmount)} ml. more necessary!");
            }
        }
    }
}
