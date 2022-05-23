using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            switch (dataType)
            {
                case "int":
                    int num1 = int.Parse(Console.ReadLine());
                    int num2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(num1, num2)); 
                    break;

                case "char":
                    char char1 = char.Parse(Console.ReadLine());
                    char char2 = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(char1, char2));
                    break;

                case "string":
                    string first = Console.ReadLine();
                    string second = Console.ReadLine();
                    Console.WriteLine(GetMax(first, second));
                    break;

                default:
                    break;
            }
        }

        private static int GetMax(int num1, int num2)
        {
            if (num1 >= num2)
            {
                return num1;
            }

            return num2;
        }

        private static char GetMax(char char1, char char2)
        {
            if (char1.CompareTo(char2) >= 0)
            {
                return char1;
            }            
            
            return char2;
        }

        private static string GetMax(string first, string second)
        {
            if (first.CompareTo(second) >= 0)
            {
                return first;
            }

            return second;
        }

    }
}
