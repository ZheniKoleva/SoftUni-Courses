using System;

namespace _05.CareOfPuppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodInKg = int.Parse(Console.ReadLine());

            int foodInGrams = foodInKg * 1000;
            int eatenInGrams = 0;
            string input = Console.ReadLine();

            while (input != "Adopted")
            {
                eatenInGrams += int.Parse(input);

                input = Console.ReadLine();

            }

            int difference = foodInGrams - eatenInGrams;

            if (foodInGrams >= eatenInGrams)
            {
                Console.WriteLine($"Food is enough! Leftovers: {difference} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {Math.Abs(difference)} grams more.");
            }
        }
    }
}
