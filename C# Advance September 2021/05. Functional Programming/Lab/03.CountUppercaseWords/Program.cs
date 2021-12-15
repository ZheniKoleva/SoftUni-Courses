using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isStartWithUpper = x => char.IsUpper(x[0]);

            var text = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => isStartWithUpper(x));

            Console.WriteLine(string.Join(Environment.NewLine, text));
        }
    }
}
