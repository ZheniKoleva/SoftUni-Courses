using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startYield = int.Parse(Console.ReadLine());

            const int consumed = 26;
            int totalYield = 0;
            int days = 0;

            while (startYield >= 100)
            {
                days++;
                totalYield += startYield;
                totalYield -= consumed;
                startYield -= 10;
            }

            if (totalYield >= consumed)
            {
                totalYield -= consumed;
            }

            Console.WriteLine(days);
            Console.WriteLine(totalYield);
        }
    }
}
