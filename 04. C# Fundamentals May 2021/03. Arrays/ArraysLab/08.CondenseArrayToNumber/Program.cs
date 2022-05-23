using System;
using System.Linq;

namespace _08.CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            //numbers = CondenseArray(numbers);

            while (numbers.Length > 1)
            {
                int[] temp = new int[numbers.Length - 1];

                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    temp[i] = numbers[i] + numbers[i + 1];
                }

                numbers = temp;
            }


            Console.WriteLine(numbers[0]);

        }

        //private static int[] CondenseArray(int[] numbers)
        //{
        //    while (numbers.Length > 1)
        //    {
        //        int[] temp = new int[numbers.Length - 1];

        //        for (int i = 0; i < numbers.Length - 1; i++)
        //        {
        //            temp[i] = numbers[i] + numbers[i + 1];
        //        }

        //        numbers = temp;
        //    }

        //    return numbers;
        //}
    }
}
