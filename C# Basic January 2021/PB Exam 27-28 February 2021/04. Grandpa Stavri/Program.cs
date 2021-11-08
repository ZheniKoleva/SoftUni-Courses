using System;

namespace _04.GrandpaStavri
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysCount = int.Parse(Console.ReadLine());

            double liters = 0.00;
            double degrees = 0.00;

            for (int day = 1; day <= daysCount; day++)
            {
                double currentLiters = double.Parse(Console.ReadLine());
                double currentDegrees = double.Parse(Console.ReadLine()) * currentLiters;
                liters += currentLiters;
                degrees += currentDegrees;

            }

            degrees /= liters;

            Console.WriteLine($"Liter: {liters:F2}");
            Console.WriteLine($"Degrees: {degrees:F2}");

            if (degrees < 38)
            {
                Console.WriteLine("Not good, you should baking!");
            }
            else if (degrees <= 42)
            {
                Console.WriteLine("Super!");
            }
            else if (degrees > 42)
            {
                Console.WriteLine("Dilution with distilled water!");
            }
        }
    }
}
