using System;

namespace _01.Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int nylonNeeded = int.Parse(Console.ReadLine());
            int paintNeeded = int.Parse(Console.ReadLine());
            int thinnerAmount = int.Parse(Console.ReadLine());
            int hoursWork = int.Parse(Console.ReadLine());

            const double nylonPrice = 1.50;
            const double paintPrice = 14.50;
            const double thinnerPrice = 5.00;
            const double bagsPrice = 0.40;

            double nylonActual = nylonNeeded + 2;
            double paintActual = paintNeeded * 1.10;

            double materialsTotalSum = (nylonActual * nylonPrice) + (paintActual * paintPrice) +
                (thinnerAmount * thinnerPrice) + bagsPrice;
            double workersWage = (materialsTotalSum * 0.30) * hoursWork;

            double finalSum = materialsTotalSum + workersWage;
            Console.WriteLine($"Total expenses: {finalSum:f2} lv.");
        }
    }
}
