using System;

namespace _01.NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int currentNum = 1;
            bool isEqual = false;

            for (int rows = 1; rows <= n; rows++)
            {
                for (int columns = 1; columns <= rows; columns++)
                {
                    if (currentNum > n)
                    {
                        isEqual = true;
                        break;
                    }
                    Console.Write($"{currentNum} ");
                    currentNum++;
                }

                if (isEqual)
                {
                    break;
                }

                Console.WriteLine();
            }
        }
    }
}
