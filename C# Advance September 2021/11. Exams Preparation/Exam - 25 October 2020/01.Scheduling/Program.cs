using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(ReadData());
            Queue<int> threads = new Queue<int>(ReadData());
            int taskToKill = int.Parse(Console.ReadLine());

            while (tasks.Any() && threads.Any())
            {
                int currentThread = threads.Peek();
                int currentTask = tasks.Peek();

                if (currentTask == taskToKill)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {taskToKill}");
                    Console.WriteLine(string.Join(' ', threads));
                    break;
                }

                if (currentThread >= currentTask)
                {
                    tasks.Pop(); 
                }

               threads.Dequeue();                
            }

        }

        private static IEnumerable<int> ReadData()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
        }
    }
}
