using System;

namespace _02.RectangleOfNxNStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(new string('*', n));
            }
        }
    }
}
