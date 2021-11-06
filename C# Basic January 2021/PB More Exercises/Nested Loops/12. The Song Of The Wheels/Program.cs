using System;

namespace _12.TheSongOfTheWheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int controlDigit = int.Parse(Console.ReadLine());

            int combinationCount = 0;
            int combinationFour = 0;

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <=  9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            bool isTrue = (a * b) + (c * d) == controlDigit && a < b && c > d;
                           
                            if (isTrue)
                            {
                                Console.Write($"{a}{b}{c}{d} ");
                                combinationCount++;
                                if (combinationCount == 4)
                                {
                                    combinationFour = int.Parse($"{a}{b}{c}{d}");
                                }
                            }                            
                        }
                    }
                }
            }

            if (combinationCount == 0)
            {
                Console.WriteLine("No!");
                return;
            }
            Console.WriteLine();

            if (combinationFour != 0)
            {
                Console.Write($"Password: {combinationFour}");
            }
            else
            {
                Console.WriteLine("No!");
            }
        }
    }
}
