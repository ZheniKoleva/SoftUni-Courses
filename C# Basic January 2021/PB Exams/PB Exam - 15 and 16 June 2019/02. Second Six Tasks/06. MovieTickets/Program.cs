using System;

namespace _06.MovieTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1 = int.Parse(Console.ReadLine());
            int a2 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
           

            for (int s1 = a1; s1 < a2; s1++)
            {
                char letter = (char)s1;

                for (int s2 = 1; s2 < n; s2++)
                {
                    for (int s3 = 1; s3 < n / 2; s3++)
                    {
                        int s4 = s1;
                        bool isCorrect = s4 % 2 != 0 && ((s2 + s3 + s4) % 2 != 0);

                        if (isCorrect)
                        {
                            Console.WriteLine($"{letter}-{s2}{s3}{s4}");
                        }

                    }

                }

            }
        }
    }
}
