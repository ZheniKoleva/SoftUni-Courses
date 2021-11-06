using System;

namespace _03.LuckyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());          

            for (int first = 1; first <= 9; first++)
            {
                for (int second = 1; second <= 9; second++)
                {
                    for (int third = 1; third <= 9; third++)
                    {
                        for (int fourth = 1; fourth <= 9; fourth++)
                        {
                            bool isLucky = (first + second) == (third + fourth);

                            if (isLucky && (number % (first + second) == 0))
                            {
                                Console.Write($"{first}{second}{third}{fourth} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
