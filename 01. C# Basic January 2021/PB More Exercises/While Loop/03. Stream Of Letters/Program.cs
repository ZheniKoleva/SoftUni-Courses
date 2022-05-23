using System;

namespace _03.StreamOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = string.Empty;
          
            bool hasC = false;
            bool hasO = false;
            bool hasN = false;

            string input = Console.ReadLine();

            while (input != "End")            
            {

                switch (input)
                {
                    case "c":
                        if (hasC)
                        {
                            words += input;
                        }
                        else
                        {
                            hasC = true;
                        }
                        break;

                    case "o":
                        if (hasO)
                        {
                            words += input;
                        }
                        else
                        {
                            hasO = true;
                        }
                        break;

                    case "n":
                        if (hasN)
                        {
                            words += input;
                        }
                        else
                        {
                            hasN = true;
                        }
                        break;

                    default:
                        {
                            int charSymbol = input[0];
                            if ((charSymbol >= 65 && charSymbol <= 90) || (charSymbol >= 97 && charSymbol <= 122))
                            {
                                words += input;
                            }
                            break;
                        }
                }

                if (hasC && hasO && hasN)
                {
                    Console.Write(words + " ");
                    words = string.Empty;                    
                    hasC = false;
                    hasO = false;
                    hasN = false;                    
                }

                input = Console.ReadLine();
            }            
        }
    }
}
