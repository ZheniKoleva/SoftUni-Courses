using System;

namespace _07.SafePasswordsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int passwordsMaxCount = int.Parse(Console.ReadLine());

            char A = (char)35;
            char B = (char)64;

            int combinationsCount = 0;

            for (int x = 1; x <= a; x++)
            {
                for (int y = 1; y <= b; y++)
                {
                    if (combinationsCount < passwordsMaxCount)
                    {
                        Console.Write($"{A}{B}{x}{y}{B}{A}|");
                        combinationsCount++;
                    }
                    else
                    {
                        return;
                    }

                    A++;
                    B++;

                    if (A > (char)55)
                    {
                        A = (char)35;
                    }
                    if (B > (char)96)
                    {
                        B = (char)64;
                    }
                }
            }
        }
    }
}
