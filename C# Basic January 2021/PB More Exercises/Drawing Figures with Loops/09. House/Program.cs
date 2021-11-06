using System;

namespace _09.House
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int stars = 2;
            if (n % 2 != 0)
            {
                stars = 1;
            }

            for (int rowRoof = 0; rowRoof < (n + 1) / 2; rowRoof++)
            {
                Console.Write(new string ('-', (n-1) / 2 - rowRoof));
                Console.Write(new string('*', stars));
                Console.WriteLine(new string('-', (n - 1) / 2 - rowRoof));
                stars += 2;
               
            }

            for (int rowBase = 0; rowBase < n / 2; rowBase++)
            {
                Console.Write('|');
                Console.Write(new string ('*', n- 2));
                Console.WriteLine('|');               
            }
        }
    }
}
