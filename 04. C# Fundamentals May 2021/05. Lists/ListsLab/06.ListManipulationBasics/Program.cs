using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = FillList();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                ManipulateList(numbers, parts);

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static void ManipulateList(List<int> numbers, string[] parts)
        {
            string command = parts[0];

            switch (command)
            {
                case "Add":
                    int elementToAdd = int.Parse(parts[1]);
                    numbers.Add(elementToAdd);
                    break;

                case "Remove":
                    int elementToRemove = int.Parse(parts[1]);
                    numbers.Remove(elementToRemove);
                    break;

                case "RemoveAt":
                    int indxToRemove = int.Parse(parts[1]);
                    numbers.RemoveAt(indxToRemove);
                    break;

                case "Insert":
                    int elementToInsert = int.Parse(parts[1]);
                    int index = int.Parse(parts[2]);

                    numbers.Insert(index, elementToInsert);
                    break;

            }
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
