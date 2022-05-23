using System;

namespace _02.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int[] triangle = { 1 };

            for (int row = 1; row <= number; row++)
            {
                int[] temp = new int[row];
                temp[0] = 1;

                for (int column = 1; column < temp.Length - 1 ; column++)
                {
                    temp[column] = triangle[column] + triangle[column - 1];
                }

                temp[temp.Length - 1] = 1;

                Console.WriteLine(string.Join(' ',temp));
                triangle = temp;
            }

        }
    }
}
