using System;

namespace _04.GiftsFromSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());

            for (int address = m; address >= n; address--)
            {
                bool isTrue = address % 2 == 0 && address % 3 == 0;

                if (isTrue )
                {
                    if (address == s)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write($"{address} ");
                    }

                }

            }

        }
    }
}
