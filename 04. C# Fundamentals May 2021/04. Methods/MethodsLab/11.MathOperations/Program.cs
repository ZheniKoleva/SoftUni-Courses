using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine(Calculate(num1, operation, num2));
        }

        private static double Calculate(int num1, char operation, int num2)
        {
            double result = 0;

            switch (operation)
            {
                case '+':
                   result = num1 + num2;
                   break;

                case '-':
                    result = num1 - num2;
                    break;

                case '*':
                    result = num1 * num2;
                    break;

                case '/':
                    result = (double)num1 / num2;
                    break;
            }

            return result;
        }
    }
}
