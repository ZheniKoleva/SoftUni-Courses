using System;

namespace _03.SquareOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
