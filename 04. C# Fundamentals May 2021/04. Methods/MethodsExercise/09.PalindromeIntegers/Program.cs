using System;
using System.Text;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                Console.WriteLine(IsPalindrome(input));

                input = Console.ReadLine();
            }

        }

        private static bool IsPalindrome(string input)
        {
            StringBuilder reversed = new StringBuilder(input.Length);
            //reversed.Append(input.Reverse().ToArray());

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed.Append(input[i]);
            }

            bool isPalindrome = reversed.Equals(input);

            return isPalindrome;
        }
    }
}
