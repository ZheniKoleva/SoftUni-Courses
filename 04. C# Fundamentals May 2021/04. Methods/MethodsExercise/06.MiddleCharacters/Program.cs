using System;
using System.Text;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(GetMidCharacter(input));
        }

        private static string GetMidCharacter(string input)
        {
            //StringBuilder midChar = new StringBuilder();
            string midChar = string.Empty;
            int index = input.Length / 2;          

            if (input.Length % 2 == 0)
            {
                //midChar.Append(input[index - 1]);
                midChar += input[index - 1];
            }

            //midChar.Append(input[index]);
            midChar += input[index];

            //return midChar.ToString();
            return midChar;
        }
    }
}
