using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVAT = number => number *= 1.20;

            var numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addVAT)
                .Select(x => $"{x:f2}");

            Console.WriteLine(string.Join(Environment.NewLine, numbers));
        }
    }
}
