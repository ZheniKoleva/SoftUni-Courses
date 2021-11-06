using System;

namespace _03._Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int vineYard = int.Parse(Console.ReadLine());
            double grapesPerSquare = double.Parse(Console.ReadLine());
            int wineTarget = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double harvest = vineYard * grapesPerSquare;
            double wineProduced = (harvest * 0.40) / 2.5;

            if (wineProduced < wineTarget)
            {
                Console.WriteLine("It will be a tough winter! More {0} liters wine needed.",
                    Math.Floor(wineTarget - wineProduced));
            }
            else
            {
                double difference = wineProduced - wineTarget;
                double winePerPerson = difference / workers;
                Console.WriteLine("Good harvest this year! Total wine: {0} liters.", 
                    Math.Floor(wineProduced));
                Console.WriteLine("{0} liters left -> {1} liters per person.",
                    Math.Ceiling(difference), 
                    Math.Ceiling(winePerPerson));
            }
        }
    }
}
