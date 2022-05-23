using System;
using System.Linq;

namespace _04.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //int[] upper = new int[numbers.Length / 2];
            //int[] lower = new int[numbers.Length / 2];

            //int k = numbers.Length / 4;

            //for (int i = 0; i < upper.Length; i++)
            //{
            //    if (i < k)
            //    {
            //        upper[i] = numbers[k - 1 - i];
            //    }
            //    else
            //    {
            //        upper[i] = numbers[numbers.Length - 1 - (i - k)];
            //    }

            //    lower[i] = numbers[k + i];
            //}

            int k = numbers.Length / 4;

            int[] upper = FillUpperArray(numbers, k);
            int[] lower = FillLowerrArray(numbers, k);
            int[] result = SumArrays(upper, lower);

            Console.WriteLine(string.Join(' ', result));
        }

        private static int[] FillLowerrArray(int[] numbers, int k)
        {
            int[] lower = new int[2 * k];

            for (int i = 0; i < lower.Length; i++)
            {
                lower[i] = numbers[k + i];
            }

            return lower;
        }

        private static int[] FillUpperArray(int[] numbers, int k)
        {
            int[] upper = new int[ 2 * k];

            for (int i = 0; i < upper.Length; i++)
            {
                if (i < k)
                {
                    upper[i] = numbers[k - 1 - i];
                }
                else
                {
                    upper[i] = numbers[numbers.Length - 1 - (i - k)];
                }                
            }

            return upper;
        }

        private static int[] SumArrays(int[] upper, int[] lower)
        {
            int[] result = new int[upper.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = upper[i] + lower[i];
            }

            return result;
        }
    }
}
