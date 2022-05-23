using System;

namespace _05.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {                
                Console.WriteLine($"{i} -> {IsSpecial(i)}");
            }
        }

        private static bool IsSpecial(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            if (sum == 5 || sum == 7 || sum == 11)
            {
                return true;
            }

            return false;
        }       
    }
}
