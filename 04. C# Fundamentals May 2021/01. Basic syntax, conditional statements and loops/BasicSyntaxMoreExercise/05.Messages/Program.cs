using System;

namespace _05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());

            string message = string.Empty;

            for (int i = 0; i < numbersCount; i++)
            {
                string currentDigit = Console.ReadLine();

                message += GetSymbol(currentDigit);
            }

            Console.WriteLine(message);
        }

        private static char GetSymbol(string currentDigit)
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";

            int countOgDigit = currentDigit.Length;
            int mainDigit = int.Parse(currentDigit) % 10;

            if (mainDigit == 0)
            {
                return ' ';
            }

            int offset = (mainDigit - 2) * 3;

            if (mainDigit == 8 || mainDigit == 9)
            {
                offset++;
            }
            int index = offset + (currentDigit.Length - 1);

            return letters[index];
                
        }
    }
}
