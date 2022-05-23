using System;

namespace _10.Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int dashes = (n - 1) / 2;
            int mid = -1;
            if (n % 2 == 0)
            {
                mid = 0;
            }

            for (int row = 0; row < (n + 1) / 2; row++)
            {
                Console.Write(new string('-', dashes));
                Console.Write('*');
                if (mid >= 0)
                {
                    Console.Write(new string('-', mid));
                    Console.Write('*');
                }
                Console.WriteLine(new string('-', dashes));
                dashes--;
                mid += 2;
            }

            mid = n - 4;
            dashes = 1;

            for (int row = 1; row < (n + 1) / 2; row++)
            {
                Console.Write(new string('-', dashes));
                Console.Write('*');
                if (mid >= 0)
                {
                    Console.Write(new string('-', mid));
                    Console.Write('*');
                }                
                Console.WriteLine(new string('-', dashes));
                dashes++;
                mid -= 2;
            }

        }
    }
}
