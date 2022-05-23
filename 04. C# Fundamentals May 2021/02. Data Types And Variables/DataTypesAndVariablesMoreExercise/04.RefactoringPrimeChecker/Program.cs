using System;

namespace _04.RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int endRange = int.Parse(Console.ReadLine());
            
            for (int i = 2; i <= endRange; i++)
            {
                bool isPrime = true;

                int limit = (int)Math.Sqrt(i);

                for (int devider = 2; devider <= limit; devider++)
                {
                    if (i % devider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{i} -> {isPrime.ToString().ToLower()}");
            }

        }
    }
}
