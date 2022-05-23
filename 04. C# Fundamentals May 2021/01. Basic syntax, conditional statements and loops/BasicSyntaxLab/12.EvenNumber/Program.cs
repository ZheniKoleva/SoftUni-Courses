using System;

namespace _12.EvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            while (number % 2 == 1)
            {
                Console.WriteLine("Please write an even number.");
                number = Math.Abs(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine($"The number is: {number}");
        }
    }
}
