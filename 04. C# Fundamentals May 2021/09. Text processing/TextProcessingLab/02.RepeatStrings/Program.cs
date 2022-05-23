using System;
using System.Text;

namespace _02.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            StringBuilder result = new StringBuilder();

            foreach (var word in input)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    result.Append(word);
                }
            }

            Console.WriteLine(result);           
        }
    }
}
