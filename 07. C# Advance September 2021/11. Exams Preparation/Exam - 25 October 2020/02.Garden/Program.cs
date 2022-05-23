using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] gardenSize = ReadData(Console.ReadLine());

            int[,] garden = new int[gardenSize[0], gardenSize[1]];
            FillGarden(garden);

            List<int[]> flowers = new List<int[]>();

            string line;

            while ((line = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = ReadData(line);
                int row = coordinates[0];
                int col = coordinates[1];

                if (!IsCoordinatesValid(garden, row, col))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                garden[row, col] = 1;
                flowers.Add(new int[] { row, col });
            }

            BloomFlowers(garden, flowers);
            PrintGarden(garden);

        }

        private static void PrintGarden(int[,] garden)
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write($"{garden[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static void BloomFlowers(int[,] garden, List<int[]> flowers)
        {
            foreach (var flower in flowers)
            {
                int flowerRow = flower[0];
                int flowerCol = flower[1];

                for (int row = 0; row < garden.GetLength(1); row++)
                {
                    if (row != flowerRow)
                    {
                        garden[row, flowerCol] += 1;
                    }
                }

                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    if (col != flowerRow)
                    {
                        garden[flowerRow, col] += 1;
                    }
                }
            }
        }

        private static bool IsCoordinatesValid(int[,] garden, int row, int col)
        {
            return row >= 0 && row < garden.GetLength(0)
                && col >= 0 && col < garden.GetLength(1);
        }

        private static void FillGarden(int[,] garden)
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    garden[row, col] = 0;
                }
            }
        }

        private static int[] ReadData(string line)
        {
            return line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
