using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMinNumber(first, second, third));
        }

        private static int GetMinNumber(int first, int second, int third)
        {
            int[] numbers = { first, second, third };
            Array.Sort(numbers);

            return numbers[0];
        }

        //private static int GetMinNumber(int first, int second, int third)
        //{
        //    return Math.Min(first, Math.Min(second, third));
        //}
    }
}
