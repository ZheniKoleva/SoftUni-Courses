using System;

namespace _06.SumAndProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());            

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 9; b >= a; b--)
                {
                    for (int c = 0; c <= 9; c++)
                    {
                        for (int d = 9; d >= c; d--)
                        {
                            bool isTrueFirst = (a + b + c + d) == (a * b * c * d) && n % 10 == 5;
                            bool isTrueSecond = (a * b * c * d) / (a + b + c + d) == 3 && n % 3 == 0;

                            if (isTrueFirst)
                            {
                                Console.WriteLine($"{a}{b}{c}{d}");
                                return;
                            }
                            else if (isTrueSecond)
                            {
                                Console.WriteLine($"{d}{c}{b}{a}");
                                return;
                            }

                        }

                    }

                }

            }

            Console.WriteLine("Nothing found");
        }
    }
}
