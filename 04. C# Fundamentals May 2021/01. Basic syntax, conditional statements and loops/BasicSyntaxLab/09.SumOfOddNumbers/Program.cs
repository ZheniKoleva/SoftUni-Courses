using System;

namespace _09.SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCount = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 1; i < numberCount * 2; i += 2)
            {
                Console.WriteLine(i);
                sum += i;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
