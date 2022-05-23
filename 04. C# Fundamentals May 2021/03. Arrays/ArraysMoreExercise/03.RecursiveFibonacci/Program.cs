using System;

namespace _03.RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int[] fibonacci = new int[number];            

            for (int i = 0; i < fibonacci.Length; i++)
            {
                if (i == 0 || i == 1)
                {
                    fibonacci[i] = 1;
                }
                else
                {
                    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
                }
            }

            Console.WriteLine(fibonacci[fibonacci.Length - 1]);
        }
    }
}
