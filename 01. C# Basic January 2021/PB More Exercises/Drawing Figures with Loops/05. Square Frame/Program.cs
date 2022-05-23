using System;

namespace _05.SquareFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                if (row == 0 || row == n - 1)
                {
                    Console.Write($"+ ");
                    for (int i = 1 ; i < n - 1; i++)
                    {
                        Console.Write("- ");
                    }
                    Console.Write('+');
                }
                else
                {
                    Console.Write($"| ");
                    for (int i = 1; i < n - 1; i++)
                    {
                        Console.Write("- ");
                    }
                    Console.Write('|');
                }

                Console.WriteLine();
            }
        }
    }
}
