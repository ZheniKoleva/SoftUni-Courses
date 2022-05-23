using System;
using System.Text;

namespace _04.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            StringBuilder input = new StringBuilder(Console.ReadLine());

            foreach (var word in bannedWords)
            {   
                input.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(input);
        }
    }
}
