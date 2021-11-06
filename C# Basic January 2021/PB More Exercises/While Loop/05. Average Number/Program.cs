using System;

namespace _05.AverageNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

           double sumNumbers = 0.00;          

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sumNumbers += number;
            }

            Console.WriteLine($"{(sumNumbers / n):f2}");
        }
    }
}
