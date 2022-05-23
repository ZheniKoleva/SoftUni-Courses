using System;
using System.Collections.Generic;
using System.Text;

namespace _04.MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
               .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(DecodeMessage(words));
        }

        private static StringBuilder DecodeMessage(string[] words)
        {
            StringBuilder result = new StringBuilder();

            foreach (var word in words)
            {
                string[] letters = word.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var letterCode in letters)
                {
                    result.Append(GetLetter(letterCode));
                }
                result.Append(' ');
            }

            return result;
        }

        private static char GetLetter(string letterCode)
        {
            Dictionary<string, char> morseCode = new Dictionary<string, char>(26);
            morseCode[".-"] = 'A';
            morseCode["-..."] = 'B';
            morseCode["-.-."] = 'C';
            morseCode["-.."] = 'D';
            morseCode["."] = 'E';
            morseCode["..-."] = 'F';
            morseCode["--."] = 'G';
            morseCode["...."] = 'H';
            morseCode[".."] = 'I';
            morseCode[".---"] = 'J';
            morseCode["-.-"] = 'K';
            morseCode[".-.."] = 'L';
            morseCode["--"] = 'M';
            morseCode["-."] = 'N';
            morseCode["---"] = 'O';
            morseCode[".--."] = 'P';
            morseCode["--.-"] = 'Q';
            morseCode[".-."] = 'R';
            morseCode["..."] = 'S';
            morseCode["-"] = 'T';
            morseCode["..-"] = 'U';
            morseCode["...-"] = 'V';
            morseCode[".--"] = 'W';
            morseCode["-..-"] = 'X';
            morseCode["-.--"] = 'Y';
            morseCode["--.."] = 'Z';

            return morseCode[letterCode];
        }
    }
}
