using System;

namespace _03.Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counterIsTrue = 0;

            for (int x1 = 0; x1 <= n; x1++)
            {
                for (int x2 = 0; x2 <= n ; x2++)
                {
                    for (int x3 = 0; x3 <= n ; x3++)
                    {
                        bool isTrue = x1 + x2 + x3 == n;
                        if (isTrue)
                        {
                            counterIsTrue++;
                        }
                    }
                }
            }

            Console.WriteLine(counterIsTrue);
        }
    }
}
