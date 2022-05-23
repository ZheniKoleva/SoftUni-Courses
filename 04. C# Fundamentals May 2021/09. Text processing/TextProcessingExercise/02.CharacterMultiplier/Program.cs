using System;
using System.Linq;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string first = input[0];
            string second = input[1];

            Console.WriteLine(SumCharacters(first, second));
        }

        private static long SumCharacters(string first, string second)
        {
            long result = 0;
            string smaller = first.Length < second.Length ? first : second;
            string bigger = first.Length >= second.Length ? first : second;

            for (int i = 0; i < smaller.Length; i++)
            {
                result += first[i] * second[i];
            }

            string reminder = bigger.Substring(smaller.Length);

            result += reminder.Sum(x => x);

            return result;
        }
    }
}
