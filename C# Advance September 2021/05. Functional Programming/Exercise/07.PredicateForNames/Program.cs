using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            Predicate<string> isLengthValid = x => x.Length <= length;

            var names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => isLengthValid(x));

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
