using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<int> digits = GetDigits(text);
            List<char> letters = GetLetters(text);

            List<int> takeList = TakeDigitsEvenOddIndx(digits, 0);
            List<int> skipList = TakeDigitsEvenOddIndx(digits, 1);

            string decodedmessage = DecodeMessage(letters, takeList, skipList);

            Console.WriteLine(decodedmessage);
        }

        private static string DecodeMessage(List<char> letters, List<int> takeList, List<int> skipList)
        {
            StringBuilder decoded = new StringBuilder();

            int startIndx = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                int elementsToTake = takeList[i];
                int elementsToSkip = skipList[i];

                for (int j = startIndx; j < letters.Count; j++)
                {
                    if (elementsToTake <= 0)
                    {
                        break;
                    }

                    decoded.Append(letters[j]);
                    startIndx++;

                    elementsToTake--;
                }

                //while (elementsToTake > 0)
                //{
                //    decoded.Append(letters[startIndx++]);
                //    elementsToTake--;
                //}

                startIndx += elementsToSkip;
            }

            return decoded.ToString();
        }

        private static List<int> TakeDigitsEvenOddIndx(List<int> digits, int parity)
        {
            int startIndx = parity == 0 ? 0 : 1;

            List<int> result = new List<int>(digits.Count / 2);

            for (int i = startIndx; i < digits.Count; i += 2)
            {
                result.Add(digits[i]);
            }

            return result;
        }

        private static List<char> GetLetters(string text)
        {
            List<char> letters = new List<char>();

            foreach (var item in text)
            {
                if (!char.IsDigit(item))
                {
                    letters.Add(item);
                }
            }

            return letters;
        }

        private static List<int> GetDigits(string text)
        {
            List<int> digits = new List<int>();

            foreach (var item in text)
            {
                if (char.IsDigit(item))
                {
                    digits.Add(item - '0');
                }
            }

            return digits;
        }
    }
}
