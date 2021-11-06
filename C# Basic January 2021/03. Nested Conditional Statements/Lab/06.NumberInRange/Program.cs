using System;

namespace _06.NumberInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool isInInterval = (number >= -100) && (number <= 100) && (number != 0);

            if (isInInterval)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}
