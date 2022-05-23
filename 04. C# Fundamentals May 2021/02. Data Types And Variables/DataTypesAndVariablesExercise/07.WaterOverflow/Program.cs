using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            const int capasity = 255;
            int waterInTank = 0;

            byte lines = byte.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                int current = int.Parse(Console.ReadLine());

                if (waterInTank + current > capasity)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }

                waterInTank += current;
            }

            Console.WriteLine(waterInTank);
        }
    }
}
