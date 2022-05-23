using System;

namespace _04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string reversed = string.Empty;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed += input[i];
            }

            Console.WriteLine(reversed);
        }
    }
}
