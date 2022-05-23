using System;

namespace _05.PuppyCare
{
    class Program
    {
        static void Main(string[] args)
        {
            int boughtFoodInKg = int.Parse(Console.ReadLine());

            int boughtFoodinGrams = boughtFoodInKg * 1000;
            int eatenInGrams = 0;
            string input = Console.ReadLine();

            while (input != "Adopted")
            {
                eatenInGrams += int.Parse(input);

                input = Console.ReadLine();

            }

            int difference = Math.Abs(boughtFoodinGrams - eatenInGrams);

            if (boughtFoodinGrams >= eatenInGrams)
            {
                Console.WriteLine($"Food is enough! Leftovers: {difference} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {difference} grams more.");
            }

        }
    }    
}
