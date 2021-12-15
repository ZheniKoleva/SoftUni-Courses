using System;
using System.Linq;

namespace _07.PredicateForNames2
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            Func<string, int, bool> isLengthValid = (x, y) => x.Length <= y;

            var names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => isLengthValid(x, length));

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
