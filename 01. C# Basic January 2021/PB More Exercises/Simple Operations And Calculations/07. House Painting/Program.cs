using System;

namespace _07._HousePainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double areaFrontAndBackWalls = (x * x) * 2 - 2.4;
            double areaSidesWalls = ((x * y) - 2.25) * 2;
            double areaRoof = (x * y) * 2 + ((x * h) / 2) * 2;

            double areaWallsTotal = areaFrontAndBackWalls + areaSidesWalls;

            double greenPaint = areaWallsTotal / 3.4;
            double redPaint = areaRoof / 4.3;

            Console.WriteLine("{0:f2}", greenPaint);
            Console.WriteLine("{0:f2}", redPaint);
        }
    }
}
