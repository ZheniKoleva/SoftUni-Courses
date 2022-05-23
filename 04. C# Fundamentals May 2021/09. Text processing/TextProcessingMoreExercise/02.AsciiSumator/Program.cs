using System;

namespace _02.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            Console.WriteLine(CalculateAsciiSum(first, second, input));
        }

        private static int CalculateAsciiSum(char first, char second, string input)
        {
            int sum = 0;

            //char smaller = first.CompareTo(second) < 0 ? first : second;
            //char bigger = second.CompareTo(first) > 0 ? second : first;

            int min = Math.Min(first, second);
            int max = Math.Max(first, second);

            foreach (var item in input)
            {
                //if (item > smaller && item < bigger)
                //{
                //    sum += item;
                //}

                if (item > min && item < max)
                {
                    sum += item;
                }
            }          

            return sum;
        }
    }
}
