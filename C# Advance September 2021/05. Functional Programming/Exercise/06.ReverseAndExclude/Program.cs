using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse);               

            int devider = int.Parse(Console.ReadLine());

            Func<int, int, bool> filter = (x, y) => x % y != 0;

            var filtered = numbers.Where(x => filter(x, devider)).Reverse();

            Console.WriteLine(string.Join(' ', filtered));
        }
    }
}
