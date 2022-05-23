using System;

namespace _01.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            switch (dataType)
            {
                case "int":
                    int number = int.Parse(Console.ReadLine());
                    PrintResult(number);
                    break;

                case "real":
                    double realNumber = double.Parse(Console.ReadLine());
                    PrintResult(realNumber);
                    break;

                case "string":
                    string input = Console.ReadLine();
                    PrintResult(input);
                    break;               
            }
        }

        private static void PrintResult(int number, int multiplier = 2)
        {
            Console.WriteLine(number * multiplier);
        }

        private static void PrintResult(double number, double multiplier = 1.5)
        {
            Console.WriteLine($"{(number * multiplier):f2}");
        }

        private static void PrintResult(string input, char surround = '$')
        {
            Console.WriteLine($"{surround}{input}{surround}");
        }
    }
}
