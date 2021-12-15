using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];
            int beeRow = -1;
            int beeCol = -1;
            FillMatrix(matrix, ref beeRow, ref beeCol);

            int polinatedFlowers = 0;
            bool isLost = false;
            string direction;

            while ((direction = Console.ReadLine()) != "End")
            {
                matrix[beeRow, beeCol] = '.';
                MoveBee(direction, ref beeRow, ref beeCol);

                if (!IsValidPosition(matrix, beeRow, beeCol))
                {
                    isLost = true;
                    break;
                }

                if (matrix[beeRow, beeCol].Equals('O'))
                {
                    matrix[beeRow, beeCol] = '.';
                    MoveBee(direction, ref beeRow, ref beeCol);

                    if (!IsValidPosition(matrix, beeRow, beeCol))
                    {
                        isLost = true;
                        break;
                    }
                }

                if (matrix[beeRow, beeCol].Equals('f'))
                {
                    polinatedFlowers++;                    
                }
               

                matrix[beeRow, beeCol] = 'B';
            }

            if (isLost)
            {
                Console.WriteLine("The bee got lost!");
            }

            int flowerToPolinate = 5;

            Console.WriteLine(polinatedFlowers < flowerToPolinate
                ? $"The bee couldn't pollinate the flowers, she needed {flowerToPolinate - polinatedFlowers} flowers more"
                : $"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsValidPosition(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

        private static void MoveBee(string direction, ref int beeRow, ref int beeCol)
        {
            switch (direction)
            {
                case "up":
                    beeRow--;
                    break;
                case "down":
                    beeRow++;
                    break;
                case "left":
                    beeCol--;
                    break;
                case "right":
                    beeCol++;
                    break;
            }
        }

        private static void FillMatrix(char[,] matrix, ref int beeRow, ref int beeCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = chars[col];

                    if (matrix[row, col].Equals('B'))
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }
        }
    }
}
