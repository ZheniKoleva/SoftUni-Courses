using System;

namespace _01.EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int namesCount = int.Parse(Console.ReadLine());

            double[] namesPoints = new double[namesCount];

            for (int i = 0; i < namesCount; i++)
            {
                string currentName = Console.ReadLine();
                namesPoints[i] = GetPoints(currentName);
            }

            Array.Sort(namesPoints);
            //Console.WriteLine(string.Join('\n', namesPoints));

            foreach (var item in namesPoints)
            {
                Console.WriteLine(item);
            }

        }

        private static double GetPoints(string currentName)
        {
            double points = 0;
            string vowels = "AEIOUaeiou";

            foreach (char symbol in currentName)
            {
                if (vowels.Contains(symbol))
                {
                    points += symbol * currentName.Length;
                }
                else
                {
                    points += symbol / currentName.Length;
                }
            }

            return points;
        }
    }
}
