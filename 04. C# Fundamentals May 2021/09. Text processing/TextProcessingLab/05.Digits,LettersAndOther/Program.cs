using System;
using System.Text;

namespace _05.Digits_LettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            //StringBuilder[] result = { new StringBuilder(), new StringBuilder(), new StringBuilder() };

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder symbols = new StringBuilder();

            foreach (var symbol in input)
            {
                if (char.IsDigit(symbol))
                {
                    digits.Append(symbol); //result[0].Append(symbol);
                }
                else if (char.IsLetter(symbol))
                {
                    letters.Append(symbol); //result[1].Append(symbol);
                }
                else
                {
                    symbols.Append(symbol); //result[2].Append(symbol);
                }
            }

            // печат с форийч
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(symbols);
        }
    }
}
