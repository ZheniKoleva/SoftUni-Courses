using System;

namespace _01.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());
            double third = double.Parse(Console.ReadLine());

            double sum = first + second + third;
            double maxNum = Math.Max(first, Math.Max(second, third));
            double minNum = Math.Min(first, Math.Min(second, third));
            double midNum = sum - (maxNum + minNum);

            Console.WriteLine(maxNum);
            Console.WriteLine(midNum);
            Console.WriteLine(minNum);
        }
    }
}
