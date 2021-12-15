using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.ReverseStrings2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> input = new Stack<char>(Console.ReadLine().ToCharArray());
            
            while (input.Any())
            {
                Console.Write(input.Pop());
            }

        }
    }
    }
}
