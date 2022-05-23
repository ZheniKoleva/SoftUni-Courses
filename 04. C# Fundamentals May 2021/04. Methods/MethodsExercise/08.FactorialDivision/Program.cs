using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            Console.WriteLine($"{DivideFactorial(first, second):f2}");

        }

        private static double DivideFactorial(int first, int second)
        {
            return GetFactorial(first) / GetFactorial(second);
        }

        private static double GetFactorial(int first)
        {
            double factorial = 1;

            for (int i = 1; i <= first; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
