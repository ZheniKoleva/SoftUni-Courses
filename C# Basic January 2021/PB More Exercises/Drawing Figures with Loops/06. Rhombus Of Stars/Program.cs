using System;

namespace _06.RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 1; row <= n; row++)
            {
                Console.Write(new string (' ', n - row));
                for (int stars = 1; stars <= row; stars++)
                {
                    Console.Write("* ");
                }                
                Console.WriteLine();
            }

            for (int row = 1; row < n; row++)
            {
                Console.Write(new string(' ', row));
                for (int stars = 1; stars <= n - row; stars++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }

        }
    }
}
