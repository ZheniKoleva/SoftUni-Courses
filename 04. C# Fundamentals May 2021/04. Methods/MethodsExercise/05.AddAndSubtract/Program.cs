using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int result = Substract(Sum(first, second), third);

            Console.WriteLine(result);
        }

        private static int Substract(int firstNum, int secondNum)
        {
            return firstNum - secondNum;
        }

        private static int Sum(int firstNum, int secondNum)
        {
            return firstNum + secondNum;
        }
    }
}
