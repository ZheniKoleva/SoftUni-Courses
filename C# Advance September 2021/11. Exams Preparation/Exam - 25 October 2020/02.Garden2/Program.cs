using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] gardenSize = ReadData(Console.ReadLine());

            int[][] garden = new int[gardenSize[0]][];
            FillGarden(garden, gardenSize[1]);

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

                garden[row][col] = 1;
                flowers.Add(new int[] { row, col });
            }

            BloomFlowers(garden, flowers);
            PrintGarden(garden);

        }

        private static void PrintGarden(int[][] garden)
        {
            foreach (var row in garden)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }

        private static void BloomFlowers(int[][] garden, List<int[]> flowers)
        {
            foreach (var flower in flowers)
            {
                int flowerRow = flower[0];
                int flowerCol = flower[1];

                for (int row = 0; row < garden.Length; row++)
                {
                    if (row != flowerRow)
                    {
                        garden[row][flowerCol]++;
                    }
                }

                for (int col = 0; col < garden[flowerRow].Length; col++)
                {
                    if (col != flowerCol)
                    {
                        garden[flowerRow][col]++;
                    }
                }
            }
        }

        private static bool IsCoordinatesValid(int[][] garden, int row, int col)
        {
            return row >= 0 && row < garden.Length
                && col >= 0 && col < garden[row].Length;
        }

        private static void FillGarden(int[][] garden, int colNumbers)
        {
            for (int row = 0; row < garden.Length; row++)
            {
                garden[row] = new int[colNumbers];
            }
        }

        private static int[] ReadData(string input)
        {
            return input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
