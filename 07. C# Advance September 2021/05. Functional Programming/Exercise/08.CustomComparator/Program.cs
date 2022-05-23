using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Comparison<int> comparator = (x, y) =>
            {   
               if (x % 2 == 0 && y % 2 != 0 )
                {
                    return -1;
                }
                else if (x % 2 != 0 && y % 2 == 0 )
                {
                    return 1;
                }

                return x.CompareTo(y);
            };

            Array.Sort(numbers, comparator);
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
