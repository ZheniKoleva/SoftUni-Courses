using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commands = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (!commands[0].Equals("1") && !numbers.Any())
                {
                    continue;
                }

                if (commands[0].Equals("1"))
                {
                    numbers.Push(int.Parse(commands[1]));

                }
                else if (commands[0].Equals("2"))
                {
                    numbers.Pop();
                }
                else if (commands[0].Equals("3"))
                {
                    Console.WriteLine(numbers.Max());
                }
                else if (commands[0].Equals("4"))
                {
                    Console.WriteLine(numbers.Min());
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
