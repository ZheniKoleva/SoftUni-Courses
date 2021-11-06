using System;

namespace _04.FoodForPets
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysCount = int.Parse(Console.ReadLine());
            double foodQuantity = double.Parse(Console.ReadLine());
            
            int eatenTotal = 0;
            int eatenByDogTotal = 0;
            int eatenByCatTotal = 0;
            double biscuitsEaten = 0;            

            for (int day = 1; day <= daysCount; day++)
            {
                int eatenByDog = int.Parse(Console.ReadLine());
                int eatenByCat = int.Parse(Console.ReadLine());

                eatenByDogTotal += eatenByDog;
                eatenByCatTotal += eatenByCat;

                int eatenPerDay = eatenByDog + eatenByCat;
                eatenTotal += eatenPerDay;

                if (day % 3 == 0)
                {
                   biscuitsEaten += eatenPerDay * 0.10;
                }

            }

            double percentEaten = (eatenTotal * 100.00) / foodQuantity;
            double percentEatenByDog = (eatenByDogTotal * 100.00) / eatenTotal;
            double percentEatenByCat = (eatenByCatTotal * 100.00) / eatenTotal;

            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuitsEaten)}gr.");
            Console.WriteLine($"{percentEaten:f2}% of the food has been eaten.");
            Console.WriteLine($"{percentEatenByDog:f2}% eaten from the dog.");
            Console.WriteLine($"{percentEatenByCat:f2}% eaten from the cat.");
        }
    }
}
