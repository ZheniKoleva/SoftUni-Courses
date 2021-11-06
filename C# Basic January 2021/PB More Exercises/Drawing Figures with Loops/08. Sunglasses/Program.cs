using System;

namespace _08.Sunglasses
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
                    Console.Write(new string ('*', 2 * n));
                    Console.Write(new string(' ', n));
                    Console.Write(new string('*', 2 * n));
                }
                else
                {
                    Console.Write('*');
                    Console.Write(new string('/', 2 * n - 2));
                    Console.Write('*');
                    if (row == (n - 1) / 2)
                    {
                        Console.Write(new string('|', n));
                    }
                    else
                    {
                        Console.Write(new string(' ', n));
                    }
                    Console.Write('*');
                    Console.Write(new string('/', 2 * n - 2));
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }
    }
}
