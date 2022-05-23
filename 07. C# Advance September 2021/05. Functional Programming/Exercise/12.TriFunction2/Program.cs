using System;
using System.Linq;

namespace _12.TriFunction2
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetSum = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isASCIISumLarger = (name, targetSum)
                => name.Sum(x => x) >= targetSum;

            Func<string[], int, Func<string, int, bool>, string> searchedName = (names, targetSum, isASCIISumLarger)
                => names.FirstOrDefault(x => isASCIISumLarger(x, targetSum));

            string name = searchedName(names, targetSum, isASCIISumLarger);

            Console.WriteLine(name);
        }
    }
}
