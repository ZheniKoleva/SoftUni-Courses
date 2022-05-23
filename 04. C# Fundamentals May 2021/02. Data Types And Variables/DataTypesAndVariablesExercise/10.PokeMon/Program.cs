using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int initialPower = power;
            int pokesCount = 0;

            while (power >= distance)
            {
                power -= distance;
                pokesCount++;

                if ((power == initialPower * 0.50) && exhaustionFactor != 0)
                {
                    power /= exhaustionFactor;
                }

            }

            Console.WriteLine(power);
            Console.WriteLine(pokesCount);
        }
    }
}
