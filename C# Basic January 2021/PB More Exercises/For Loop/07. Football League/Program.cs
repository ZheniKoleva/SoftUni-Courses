using System;

namespace _07.FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            int stadiumCapacity = int.Parse(Console.ReadLine());
            int fansNumber = int.Parse(Console.ReadLine());

            int counterA = 0;
            int counterB = 0;
            int counterV = 0;
            int counterG = 0;

            for (int i = 0; i < fansNumber; i++)
            {
                char sector = char.Parse(Console.ReadLine().ToLower());

                switch (sector)
                {
                    case 'a':
                        counterA += 1;
                        break;
                    case 'b':
                        counterB += 1;
                        break;
                    case 'v':
                        counterV += 1;
                        break;
                    case 'g':
                        counterG += 1;
                        break;                   
                }
            }
            double percentSectorA = (counterA * 100.00) / fansNumber;
            double percentSectorB = (counterB * 100.00) / fansNumber;
            double percentSectorV = (counterV * 100.00) / fansNumber;
            double percentSectorG = (counterG * 100.00) / fansNumber;
            double percentAll = (fansNumber * 100.00) / stadiumCapacity;

            Console.WriteLine($"{percentSectorA:f2}%");
            Console.WriteLine($"{percentSectorB:f2}%");
            Console.WriteLine($"{percentSectorV:f2}%");
            Console.WriteLine($"{percentSectorG:f2}%");
            Console.WriteLine($"{percentAll:f2}%");
        }
    }
}
