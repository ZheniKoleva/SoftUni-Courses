using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(ReadData());

            string line = Console.ReadLine().ToLower();

            while (line != "end")
            {
                ManipulateStack(numbers, line);

                line = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }

        private static void ManipulateStack(Stack<int> numbers, string line)
        {
            string[] data = line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = data[0].ToLower();

            switch (command)
            {
                case "add":
                    numbers.Push(int.Parse(data[1]));
                    numbers.Push(int.Parse(data[2]));
                    break;

                case "remove":
                    int numsToRemove = int.Parse(data[1]);

                    if (numsToRemove <= numbers.Count)
                    {
                        for (int i = 0; i < numsToRemove; i++)
                        {
                            numbers.Pop();
                        }
                    }

                    break;
            }
        }

        private static IEnumerable<int> ReadData()
        {
            return Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse);
        }

    }
}
