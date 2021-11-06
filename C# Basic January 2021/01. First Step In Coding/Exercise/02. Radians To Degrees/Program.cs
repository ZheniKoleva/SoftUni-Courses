using System;

namespace _02._RadiansToDegrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double radians = double.Parse(Console.ReadLine());

            double degrees = radians * 180 / Math.PI;
            Console.WriteLine(Math.Round(degrees, 0));
        }
    }
}
