using System;

namespace _04.ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);

           Array.Reverse(array);

            Console.WriteLine(string.Join(' ', array));
        }
    }
}
