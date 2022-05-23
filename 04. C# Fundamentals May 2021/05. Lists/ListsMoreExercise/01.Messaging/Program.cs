using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = ReadInput();
            string text = Console.ReadLine();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < numbers.Count; i++)
            {
                int indxToTake = GetElementSum(numbers[i]);                 
                
                text = GetMessage(output, text, indxToTake);

            }

            Console.WriteLine(output.ToString());

        }

        private static string GetMessage(StringBuilder output, string text, int indxToTake)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (i == indxToTake)
                {
                    output.Append(text[indxToTake]);
                    text = text.Remove(indxToTake, 1);
                    break;
                }

                if (i == text.Length - 1 && indxToTake >= text.Length)
                {
                    indxToTake -= text.Length;
                    i = -1;
                }
            }

            return text;
        }

        private static int GetElementSum(int number)
        {
            int sumOfDigits = 0;

            while (number > 0)
            {
                sumOfDigits += number % 10;
                number /= 10;
            }

            return sumOfDigits;
        }

        private static List<int> ReadInput()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}
