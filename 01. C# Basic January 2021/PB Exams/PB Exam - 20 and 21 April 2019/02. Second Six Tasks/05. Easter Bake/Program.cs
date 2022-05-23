using System;

namespace _05.EasterBake
{
    class Program
    {
        static void Main(string[] args)
        {
            int easternBreadCount = int.Parse(Console.ReadLine());

            const int sugarPackageAmount = 950;
            const int flourPackageAmount = 750;

            int sugarUsedTotal = 0;
            int flourUsedTotal = 0;

            int sugarUsedMax = int.MinValue;
            int flourUsedMax = int.MinValue;

            for (int i = 0; i < easternBreadCount; i++)
            {
                int sugarUsed = int.Parse(Console.ReadLine());
                int flourUsed = int.Parse(Console.ReadLine());
                sugarUsedTotal += sugarUsed;
                flourUsedTotal += flourUsed;

                if (sugarUsed > sugarUsedMax)
                {
                    sugarUsedMax = sugarUsed;
                }
                if (flourUsed > flourUsedMax)
                {
                    flourUsedMax = flourUsed;
                }
            }

            double sugarPackages = Math.Ceiling(1.0 * sugarUsedTotal / sugarPackageAmount);
            double flourPackages = Math.Ceiling(1.0 * flourUsedTotal / flourPackageAmount);

            Console.WriteLine($"Sugar: {sugarPackages}");
            Console.WriteLine($"Flour: {flourPackages}");
            Console.WriteLine($"Max used flour is {flourUsedMax} grams, max used sugar is {sugarUsedMax} grams.");
        }
    }
}
