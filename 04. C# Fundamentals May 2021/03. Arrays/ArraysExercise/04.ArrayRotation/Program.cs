using System;

namespace _04.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] current = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int rotationsCount = int.Parse(Console.ReadLine());
            //int rotations = rotationsCount % current.Length;

            for (int i = 0; i < rotationsCount; i++) // rotations
            {
                string firstElement = current[0];

                for (int j = 1; j < current.Length; j++)
                {
                    current[j - 1] = current[j];
                }

                current[current.Length - 1] = firstElement;
            }

            Console.WriteLine(string.Join(' ', current));

        }
    }
}
