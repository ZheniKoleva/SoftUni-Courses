using System;

namespace _02.EnglishNameLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string output = GetLastDigitAsText(number);

            Console.WriteLine(output);
        }

        private static string GetLastDigitAsText(int number)
        {
            int lastDigit = number % 10;

            string[] digitsName = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
            string output = digitsName[lastDigit];

            return output;
            
        }
    }
}
