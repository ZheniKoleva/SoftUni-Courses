using System;

namespace _04.TriangleOfDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column <= row; column++)
                {
                    Console.Write("$ ");
                }
                Console.WriteLine();
            }
        }
    }
}
