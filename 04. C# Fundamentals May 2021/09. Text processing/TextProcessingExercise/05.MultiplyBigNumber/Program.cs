using System;
using System.Text;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string digitAsString = Console.ReadLine();
            int multiplayer = int.Parse(Console.ReadLine());
           
            Console.WriteLine(MultiplyNumbersAsString(digitAsString, multiplayer));
        }

        private static string MultiplyNumbersAsString(string digit, int multiplayer)
        {            
            if (multiplayer == 0)
            {
                return "0";
            }

            StringBuilder result = new StringBuilder();
            int reminder = 0;

            for (int i = digit.Length - 1; i >= 0; i--)
            {
                int currentDigit = int.Parse(digit[i].ToString());                
                int currrentResult = (currentDigit * multiplayer) + reminder;

                reminder = 0;

                if (currrentResult > 9)
                {
                    reminder = currrentResult / 10;
                    currrentResult %= 10;
                }

                result.Append(currrentResult);
            }

            if (reminder > 0)
            {
                result.Append(reminder);
            }
            
            char[] array = result.ToString().ToCharArray();
            Array.Reverse(array);
            string output = new string(array);

            return output;
        }
    }
}
