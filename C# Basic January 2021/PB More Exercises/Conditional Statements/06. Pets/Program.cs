using System;

namespace _06._Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysCount = int.Parse(Console.ReadLine());
            double amountFood = int.Parse(Console.ReadLine());
            double dogFoodPerDay = double.Parse(Console.ReadLine());
            double catFoodPerDay = double.Parse(Console.ReadLine());
            double turtleFoodPerDay = double.Parse(Console.ReadLine());

            double dogFoodEaten = dogFoodPerDay * daysCount;
            double catFoodEaten = catFoodPerDay * daysCount;
            double turtleFoodEaten = (turtleFoodPerDay * daysCount) / 1000;

            double foodEaten = dogFoodEaten + catFoodEaten + turtleFoodEaten;

            if (foodEaten <= amountFood)
            {
                Console.WriteLine("{0} kilos of food left.", Math.Floor(amountFood - foodEaten));
            }
            else
            {
                Console.WriteLine("{0} more kilos of food are needed.", Math.Ceiling(foodEaten - amountFood));
            }

        }
    }
}
