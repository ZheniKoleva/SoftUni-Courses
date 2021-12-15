using System;
using System.Linq;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printNames = x => Console.WriteLine(x);

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(printNames);
        }
    }
}
