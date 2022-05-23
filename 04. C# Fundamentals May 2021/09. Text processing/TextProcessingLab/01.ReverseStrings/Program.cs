using System;
using System.Text;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                //string reversed = Reverse(input);

                Console.WriteLine($"{input} = {Reverse(input)}");

                input = Console.ReadLine();
            }
        }

        private static string Reverse(string input)
        {
            StringBuilder reversed = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed.Append(input[i]);
            }

            return reversed.ToString();
        }
    }
}
