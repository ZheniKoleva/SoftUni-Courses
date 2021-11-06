using System;

namespace _02.CatWalking
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesWalking = int.Parse(Console.ReadLine());
            int walkingsCount = int.Parse(Console.ReadLine());
            int caloriesTakenPerDay= int.Parse(Console.ReadLine());

            const int caloriesBurnedPerMin = 5;

            int caloriesBurnedPerDay = walkingsCount * minutesWalking * caloriesBurnedPerMin;

            double caloriesBurnedNeeded = (1.0 * caloriesTakenPerDay) / 2;

            if (caloriesBurnedPerDay >= caloriesBurnedNeeded)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {caloriesBurnedPerDay}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {caloriesBurnedPerDay}.");
            }

        }
    }
}
