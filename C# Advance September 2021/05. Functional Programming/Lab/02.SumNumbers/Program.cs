using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {  
            var inputNumbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(Parser);

            Console.WriteLine(inputNumbers.Count());
            Console.WriteLine(inputNumbers.Sum());
        }

        private static int Parser(string numberAsString)
        {
            int number = 0;

            foreach (var symbol in numberAsString)
            {
                number *= 10;
                number += (symbol - '0');
            }

            return number;
        }
    }
}
