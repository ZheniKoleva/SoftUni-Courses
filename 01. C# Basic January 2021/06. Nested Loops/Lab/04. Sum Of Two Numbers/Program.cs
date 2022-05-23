using System;

namespace _04.SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int combinationsCount = 0;

            for (int firstDigit = start; firstDigit <= end; firstDigit++)
            {
                for (int secondDigit = start; secondDigit <= end; secondDigit++)
                {
                    combinationsCount++;
                    bool isTrue = firstDigit + secondDigit == magicNumber;
                    if (isTrue)
                    {                       
                        Console.WriteLine($"Combination N:{combinationsCount} " +
                            $"({firstDigit} + {secondDigit} = {magicNumber})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{combinationsCount} combinations - neither equals {magicNumber}");
        }
    }
}
