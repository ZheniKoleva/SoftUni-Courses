using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = FillList();

            bool hasChanged = false;

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] manipulationList = { "Add", "Remove", "RemoveAt", "Insert" };
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (manipulationList.Contains(command))
                {
                    ManipulateList(numbers, parts);
                    hasChanged = true;
                }
                else
                {
                    ShowCurrentCondition(numbers, parts);
                }

                line = Console.ReadLine();
            }

            if (hasChanged)
            {
                Console.WriteLine(string.Join(' ', numbers));
            }

        }

        private static void ShowCurrentCondition(List<int> numbers, string[] parts)
        {
            string command = parts[0];

            switch (command)
            {
                case "Contains":
                    int elementToCheck = int.Parse(parts[1]);
                    CheckIfIsContained(numbers, elementToCheck);
                    break;

                case "PrintEven":
                    PrintEvenOrOdd(numbers, 0);
                    break;

                case "PrintOdd":
                    PrintEvenOrOdd(numbers, 1);
                    break;

                case "GetSum":
                    Console.WriteLine(numbers.Sum());
                    break;

                case "Filter":
                    string condition = parts[1];
                    int number = int.Parse(parts[2]);
                    PrintFilteredList(numbers, condition, number);
                    break;
            }

        }

        private static void PrintFilteredList(List<int> numbers, string condition, int number)
        {    
            switch (condition)
            {
                case "<":
                    Console.WriteLine(string.Join(' ', numbers.Where(x => x < number)));
                    break;

                case ">":
                    Console.WriteLine(string.Join(' ', numbers.Where(x => x > number)));
                    break;

                case ">=":
                    Console.WriteLine(string.Join(' ', numbers.Where(x => x >= number)));
                    break;

                case "<=":
                    Console.WriteLine(string.Join(' ', numbers.Where(x => x <= number)));
                    break;
                
            }
        }

        private static void PrintEvenOrOdd(List<int> numbers, int parity)
        {           
            Console.WriteLine(string.Join(' ', numbers.Where(x => x % 2 == parity)));                
        }

        private static void CheckIfIsContained(List<int> numbers, int elementToCheck)
        {
            Console.WriteLine(numbers.Contains(elementToCheck) ? "Yes" : "No such number");
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
