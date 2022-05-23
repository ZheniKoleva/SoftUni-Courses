using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = FillList();
            int[] commands = FillArray();

            int bomb = commands[0];
            int bombPower = commands[1];

            DetonateBomb(numbers, bomb, bombPower);

            Console.WriteLine(numbers.Sum());
                
        }

        private static void DetonateBomb(List<int> numbers, int bomb, int bombPower)
        {
            while (numbers.Contains(bomb))
            {
                int bombIndx = numbers.IndexOf(bomb);

                int startIndx = GetStartIndx(bombIndx, bombPower);
                int endIndx = GetEndIndx(numbers, bombIndx, bombPower);
                int radius = endIndx - startIndx + 1;

                numbers.RemoveRange(startIndx, radius);
            }
        }

        private static int GetEndIndx(List<int> numbers, int bombIndx, int bombPower)
        {
            int endIndx = bombIndx + bombPower;

            if (endIndx >= numbers.Count)
            {
                endIndx = numbers.Count - 1;
            }

            return endIndx;
        }

        private static int GetStartIndx(int bombIndx, int bombPower)
        {
            int startIndx = bombIndx - bombPower;

            if (startIndx < 0)
            {
                startIndx = 0;
            }

            return startIndx;
        }

        private static int[] FillArray()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private static List<int> FillList()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}
