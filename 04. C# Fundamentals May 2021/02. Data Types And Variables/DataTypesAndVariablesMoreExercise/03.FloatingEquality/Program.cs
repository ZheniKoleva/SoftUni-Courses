using System;

namespace _03.FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            double reference = 0.000001;

            double difference = Math.Abs(Math.Max(num1, num2) - Math.Min(num1, num2));

            bool isEquals = difference < reference;

            Console.WriteLine(isEquals);
        }
    }
}
