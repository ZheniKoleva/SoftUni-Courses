using System;

namespace _04.Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber < 200)
                {
                    p1++;
                }
                else if (currentNumber < 400)
                {
                    p2++;
                }
                else if (currentNumber < 600)
                {
                    p3++;
                }
                else if (currentNumber < 800)
                {
                    p4++;
                }
                else
                {
                    p5++;
                }
            }

            Console.WriteLine($"{100.0 * p1 / n:f2}%");
            Console.WriteLine($"{100.0 * p2 / n:f2}%");
            Console.WriteLine($"{100.0 * p3 / n:f2}%");
            Console.WriteLine($"{100.0 * p4 / n:f2}%");
            Console.WriteLine($"{100.0 * p5 / n:f2}%");            
        }
    }
}
