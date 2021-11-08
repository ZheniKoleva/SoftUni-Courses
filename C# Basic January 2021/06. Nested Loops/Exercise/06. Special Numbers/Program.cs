using System;

namespace _06.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int dig1 = 1; dig1 <= 9; dig1++)
            {
                for (int dig2 = 1; dig2 <= 9; dig2++)
                {
                    for (int dig3 = 1; dig3 <= 9; dig3++)
                    {
                        for (int dig4 = 1; dig4 <= 9; dig4++)
                        {
                            bool isTrue = n % dig1 == 0 && n % dig2 == 0 && n % dig3 == 0 && n % dig4 == 0;
                            
                            if (isTrue)
                            {
                                Console.Write($"{dig1}{dig2}{dig3}{dig4} ");
                            }

                        }

                    }

                }

            }

        }
    }
}
