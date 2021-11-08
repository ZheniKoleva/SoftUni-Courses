using System;

namespace _01.NumberPyramid2
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
                int columns = 1;

                while (columns <= rows)
                {
                    Console.Write($"{currentNum} ");
                    currentNum++;
                    columns++;

                    if (currentNum > n)
                    {
                        isEqual = true;
                        break;
                    }
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
