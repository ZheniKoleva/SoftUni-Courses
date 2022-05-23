using System;

namespace _05.SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            double luggageCapacity = double.Parse(Console.ReadLine());

            int suitcaseCount = 0;
            int suitcasesLoaded = 0;
            string input = Console.ReadLine();

            while (input != "End")
            {
                double suitcaseVolume = double.Parse(input);
                suitcaseCount++;

                if (suitcaseCount % 3 == 0)
                {
                    suitcaseVolume += suitcaseVolume * 0.10;
                }

                if (suitcaseVolume > luggageCapacity )
                {
                    break;
                }

                luggageCapacity -= suitcaseVolume;
                suitcasesLoaded++;
               
                input = Console.ReadLine();

            }

            if (input == "End")
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }
            else
            {
                Console.WriteLine("No more space!");
            }

            Console.WriteLine($"Statistic: {suitcasesLoaded} suitcases loaded.");
        }
    }
}
