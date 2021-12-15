using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(ReadData());
            Queue<int> roses = new Queue<int>(ReadData());
            int leftFlowers = 0;

            int wreathsNeeded = 5;
            int wreaths = 0;

            while (lilies.Any() && roses.Any() && wreaths < wreathsNeeded)
            {
                int currentSum = lilies.Peek() + roses.Peek();

                if (currentSum == 15)
                {
                    wreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (currentSum > 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }
                else
                {
                    leftFlowers += currentSum;
                    lilies.Pop();
                    roses.Dequeue();
                }

            }

            wreaths += leftFlowers / 15;

            Console.WriteLine(wreaths >= wreathsNeeded
                ? $"You made it, you are going to the competition with {wreaths} wreaths!"
                : $"You didn't make it, you need {wreathsNeeded - wreaths} wreaths more!");

        }

        private static IEnumerable<int> ReadData()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
        }
    }
}
