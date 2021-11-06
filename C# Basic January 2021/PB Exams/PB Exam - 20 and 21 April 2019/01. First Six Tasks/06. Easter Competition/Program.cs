using System;

namespace _06.EasterCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int easterBreadCount = int.Parse(Console.ReadLine());

            int pointsCounter = 0;
            int pointsMax = int.MinValue;
            string chefMaxPoints = string.Empty;

            for (int i = 1; i <= easterBreadCount; i++)
            {
                string chefName = Console.ReadLine();
                string evaluation = Console.ReadLine();

                while (evaluation != "Stop")                
                {                    
                    int evaluationPoints = int.Parse(evaluation);
                    pointsCounter += evaluationPoints;

                    evaluation = Console.ReadLine();
                }

                Console.WriteLine($"{chefName} has {pointsCounter} points.");
                if (pointsCounter > pointsMax)
                {
                    pointsMax = pointsCounter;
                    chefMaxPoints = chefName;
                    Console.WriteLine($"{chefName} is the new number 1!");
                }

                pointsCounter = 0;

            }

            Console.WriteLine($"{chefMaxPoints} won competition with {pointsMax} points!");
        }
    }
}
