using System;
using System.Linq;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(GetVolewsCount(input));
        }

        private static int GetVolewsCount(string input)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            int vowelsCount = 0;

            foreach (var item in input.ToLower())
            {
                if (vowels.Contains(item))
                {
                    vowelsCount++;
                }
            }

            return vowelsCount;
        }
    }
}
