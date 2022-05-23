using System;

namespace _04.Sequence2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = 1;

            while (n >= k)
            {
                Console.WriteLine(k);
                k = 2 * k + 1;
            }
        }
    }
}
