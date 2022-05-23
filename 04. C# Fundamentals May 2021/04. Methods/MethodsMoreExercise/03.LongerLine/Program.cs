using System;

namespace _03.LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double[] point1 = { x1, y1 };
            double[] point2 = { x2, y2 };
            double[] point3 = { x3, y3 };
            double[] point4 = { x4, y4 };

            double distanceLine1 = GetLength(point1, point2);
            double distanceLine2 = GetLength(point3, point4);

            if (distanceLine1 >= distanceLine2)
            {
                Console.WriteLine(GetCloserToCenter(point1, point2));
            }
            else
            {
                Console.WriteLine(GetCloserToCenter(point3, point4));
            }
            
        }


        private static string GetCloserToCenter(double[] coordinateA, double[] coordinateB)
        {
            double distanceA = Math.Sqrt(Math.Pow(coordinateA[0], 2) + Math.Pow(coordinateA[1], 2));
            double distanceB = Math.Sqrt(Math.Pow(coordinateB[0], 2) + Math.Pow(coordinateB[1], 2));

            if (distanceA <= distanceB)
            {
                return $"({string.Join(", ", coordinateA)})({string.Join(", ", coordinateB)})";
            }
            
            return $"({string.Join(", ", coordinateB)})({string.Join(", ", coordinateA)})";
        }

       
        private static double GetLength(double[] pointA, double[] pointB)
        {
            double lineLength = Math.Pow(Math.Abs(pointA[0] - pointB[0]), 2) + Math.Pow(Math.Abs(pointA[1] - pointB[1]), 2);

            return lineLength;
        }
    }
}
