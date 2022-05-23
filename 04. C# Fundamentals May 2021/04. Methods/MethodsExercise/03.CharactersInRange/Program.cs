using System;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            PrintCharcters(first, second);
        }

        private static void PrintCharcters(char first, char second)
        {
            char min = (char)Math.Min(first, second);
            char max = (char)Math.Max(first, second);

            int arrayLength = max - min - 1;

            if (arrayLength < 0)
            {
                arrayLength = 0;
            }

            char[] symbols = new char[arrayLength];

            for (int i = 0; i < symbols.Length; i++)
            {
                symbols[i] = (char)(++min);
            }

            Console.WriteLine(string.Join(' ', symbols));
        }
    }
}
