using System;

namespace _02.CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintClosestPoint(x1, y1, x2, y2);
        }

        private static void PrintClosestPoint(double x1, double y1, double x2, double y2)
        {
            double[] firstPoint = { x1, y1 };
            double[] secondPoint = { x2, y2 };

            double distanceFirstPoint = GetDistanceToCenter(firstPoint);
            double distanceSecondPoint = GetDistanceToCenter(secondPoint);

            if (distanceFirstPoint <= distanceSecondPoint)
            {
                Console.WriteLine($"({string.Join(", ", firstPoint)})");
            }
            else
            {
                Console.WriteLine($"({string.Join(", ", secondPoint)})");
            }
        }

        private static double GetDistanceToCenter(double[] coordinate)
        {
            double distance = Math.Sqrt(Math.Pow(Math.Abs(coordinate[0]), 2) + Math.Pow(Math.Abs(coordinate[1]), 2));

            return distance;
        }
    }
}
