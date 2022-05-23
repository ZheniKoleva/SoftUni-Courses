using System;
using System.Linq;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] second = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //for (int i = 0; i < second.Length; i++)
            //{
            //    for (int j = 0; j < first.Length; j++)
            //    {
            //        if (second[i] == first[j])
            //        {
            //            Console.Write($"{second[i]} ");
            //            break;
            //        }
            //    }
            //}

            //foreach (string item in second)
            //{
            //    foreach (string item2 in first)
            //    {
            //        if (item == item2)
            //        {
            //            Console.Write($"{item} ");
            //            break;
            //        }
            //    }
            //}

            string[] result = second.Intersect(first).ToArray();

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
