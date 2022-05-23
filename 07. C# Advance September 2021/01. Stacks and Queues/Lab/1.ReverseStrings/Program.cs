using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> input = new Stack<char>(Console.ReadLine().ToCharArray());
            StringBuilder reversed = new StringBuilder();

            while (input.Any())
            {
                reversed.Append(input.Pop());
            }

            Console.WriteLine(reversed);
        }
    }
}
