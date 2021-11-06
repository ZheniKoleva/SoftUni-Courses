using System;

namespace _01.RectangleOf_10x_10Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int row = 0; row < 10; row++)
            {
                Console.WriteLine(new string ('*', 10));
            }
        }
    }
}
