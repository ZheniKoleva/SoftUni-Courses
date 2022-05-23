using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string line = Console.ReadLine();

            while (line != "Finish")
            {
                string[] data = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = data[0];

                switch (command)
                {
                    case "Add":
                        int valueToAdd = int.Parse(data[1]);
                        numbers = AddValue(numbers, valueToAdd);
                        break;

                    case "Remove":
                        int valueToRemove = int.Parse(data[1]);
                        numbers = RemoveValue(numbers, valueToRemove);
                        break;

                    case "Replace":
                        int valueToReplace = int.Parse(data[1]);
                        int replacement = int.Parse(data[2]);   

                        Replace(numbers, valueToReplace, replacement);
                        break;

                    case "Collapse":
                        int value = int.Parse(data[1]);

                        numbers = Collapse(numbers, value);
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static int[] Collapse(int[] numbers, int value)
        {
            int[] newList = numbers.Where(x => x >= value).ToArray();

            return newList;
        }

        private static void Replace(int[] numbers, int valueToReplace, int replacement)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == valueToReplace)
                {
                    numbers[i] = replacement;
                    break;
                }
            }
        }

        private static int[] RemoveValue(int[] numbers, int valueToRemove)
        {            
            List<int> newArray = new List<int>();
            bool fisrtOccur = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == valueToRemove && !fisrtOccur)
                {
                    fisrtOccur = true;
                    continue;
                }

                newArray.Add(numbers[i]);
            }

            return newArray.ToArray();
        }

        private static int[] AddValue(int[] numbers, int valueToAdd)
        {
            int[] newArray = new int[numbers.Length + 1];

            Array.Copy(numbers, 0, newArray, 0, numbers.Length);
            newArray[newArray.Length - 1] = valueToAdd;

            return newArray;
        }
    }
}
