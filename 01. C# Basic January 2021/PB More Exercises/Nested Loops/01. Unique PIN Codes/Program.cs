using System;

namespace _01.UniquePINCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int endFirst = int.Parse(Console.ReadLine());
            int endSecond = int.Parse(Console.ReadLine());
            int endThird = int.Parse(Console.ReadLine());

            for (int firstDigit = 2; firstDigit <= endFirst; firstDigit += 2)
            {
                for (int secondDigit = 2; secondDigit <= endSecond; secondDigit++)
                {
                    for (int thirdDigit = 2; thirdDigit <= endThird; thirdDigit += 2)
                    {
                        if ((secondDigit != 2 && secondDigit % 2 == 0) || secondDigit == 9)
                        {
                            continue;
                        }                        
                        Console.WriteLine($"{firstDigit} {secondDigit} {thirdDigit}");
                    }
                }
            }
        }
    }
}

