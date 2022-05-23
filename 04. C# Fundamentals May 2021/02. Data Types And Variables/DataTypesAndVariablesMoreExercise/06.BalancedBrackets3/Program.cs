using System;

namespace _06._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            byte rows = byte.Parse(Console.ReadLine());
            byte bracketCounter = 0;

            for (int i = 1; i <= rows; i++)
            {
                string currentSymbols = Console.ReadLine();

                if (currentSymbols == "(")
                {
                    bracketCounter++;
                }
                else if (currentSymbols == ")")
                {
                    bracketCounter--;
                }

                if (bracketCounter > 1)
                {
                    break;
                }
            }

            Console.WriteLine(bracketCounter == 0 ? "BALANCED" : "UNBALANCED");
        }
    }
}

