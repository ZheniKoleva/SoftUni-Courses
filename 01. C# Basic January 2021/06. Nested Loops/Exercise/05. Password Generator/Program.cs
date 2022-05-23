using System;

namespace _05.PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int dig1 = 1; dig1 <= n; dig1++)
            {
                for (int dig2 = 1; dig2 <= n; dig2++)
                {
                    for (char let1 = 'a'; let1 < 'a' + l; let1++)
                    {
                        for (char let2 = 'a'; let2 < 'a' + l; let2++)
                        {
                            for (int dig3 = 1; dig3 <= n; dig3++)
                            {
                                bool isTrue = dig3 > dig1 && dig3 > dig2;
                                if (isTrue)
                                {
                                    Console.Write($"{dig1}{dig2}{let1}{let2}{dig3} "); 
                                }

                            }

                        }

                    }

                }

            }

        }
    }
}
