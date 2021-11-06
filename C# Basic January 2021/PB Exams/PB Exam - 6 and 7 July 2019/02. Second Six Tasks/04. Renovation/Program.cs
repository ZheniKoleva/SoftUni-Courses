using System;

namespace _04.Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            int wallsHeight = int.Parse(Console.ReadLine());
            int wallsWidth = int.Parse(Console.ReadLine());
            int percentNotPainted = int.Parse(Console.ReadLine());

            double area = wallsHeight * wallsWidth * 4;
            area -= Math.Ceiling(area * percentNotPainted / 100);

            string input = Console.ReadLine();

            while (input != "Tired!")
            {
                int paintAmount = int.Parse(input);

                area -= paintAmount;

                if (area <= 0)
                {                   
                    break;
                }

                input = Console.ReadLine();

            }

            if (area == 0)
            {
                Console.WriteLine("All walls are painted! Great job, Pesho!");
            }
            else if (area > 0)
            {
                Console.WriteLine($"{area} quadratic m left.");
                
            }
            else 
            {
                Console.WriteLine($"All walls are painted and you have {Math.Abs(area)} l paint left!");
            }

        }
    }
}
