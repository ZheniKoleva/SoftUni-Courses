using System;

namespace _08._CircleAreaAndPerimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());

            double calculatedArea = Math.PI * r * r;
            double calculatedParameter = Math.PI * r * 2;

            Console.WriteLine($"{calculatedArea:f2}");
            Console.WriteLine($"{calculatedParameter:f2}");
        }
    }
}
