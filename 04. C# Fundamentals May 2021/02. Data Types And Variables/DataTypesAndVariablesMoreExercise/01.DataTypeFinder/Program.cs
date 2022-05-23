using System;

namespace _01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string result = string.Empty;

            while (input != "END")
            {
                if (int.TryParse(input, out _))
                {
                    result = "integer";
                }
                else if (char.TryParse(input, out _))
                {
                    result = "character";
                }
                else if (double.TryParse(input, out _))
                {
                    result = "floating point";
                }
                else if (bool.TryParse(input, out _))
                {
                    result = "boolean";
                }
                else
                {
                    result = "string";
                }

                Console.WriteLine($"{input} is {result} type");

                input = Console.ReadLine();

            }

        }
    }
}
