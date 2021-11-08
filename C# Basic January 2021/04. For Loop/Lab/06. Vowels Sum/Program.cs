using System;

namespace _06.VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int vowelsSum = 0;

            for (int index = 0; index < input.Length; index++)
            {
                switch (input[index])
                {
                    case 'a':
                        vowelsSum += 1;
                        break;

                    case 'e':
                        vowelsSum += 2;
                        break;

                    case 'i':
                        vowelsSum += 3;
                        break;

                    case 'o':
                        vowelsSum += 4;
                        break;

                    case 'u':
                        vowelsSum += 5;
                        break;
                }
            }

            Console.WriteLine(vowelsSum);
        }
    }
}
