using System;
using System.Collections.Generic;

namespace _7.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> children = new Queue<string>(Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries));

            int rotations = int.Parse(Console.ReadLine());
            int currentRotation = 0;

            while (children.Count > 1)
            {
                currentRotation++;

                if (currentRotation == rotations)
                {
                    Console.WriteLine($"Removed {children.Dequeue()}");
                    currentRotation = 0;
                    continue;
                }

                children.Enqueue(children.Dequeue());
            }

            Console.WriteLine($"Last is {children.Peek()}");
        }
    }
}
