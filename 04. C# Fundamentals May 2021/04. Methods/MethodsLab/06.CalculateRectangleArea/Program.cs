using System;

namespace _06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());

            double area = GetRectangleArea(sideA, sideB);
            Console.WriteLine(area);
        }

        private static double GetRectangleArea(double sideA, double sideB)
        {
            return sideA * sideB;
        }
    }
}
