using System;
using System.Collections.Generic;
using System.Linq;


namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputData = ReadInput();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] tokens = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                switch (command)
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        inputData.Add(numberToAdd);
                        break;

                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indx = int.Parse(tokens[2]);

                        if (!IsValidIndx(inputData, indx))
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        
                        inputData.Insert(indx, numberToInsert);

                        break;

                    case "Remove":
                        int indxToRemove = int.Parse(tokens[1]);

                        if (!IsValidIndx(inputData, indxToRemove))
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }

                        inputData.RemoveAt(indxToRemove);
                        break;

                        case "Shift":
                        string direction = tokens[1];
                        int rotationsCount = int.Parse(tokens[2]);

                        ShiftElements(inputData, direction, rotationsCount);
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', inputData));
        }

        private static void ShiftElements(List<int> inputData, string direction, int rotationsCount)
        {
            int indxToTake = direction == "left" ? 0 : inputData.Count - 1;

            for (int i = 0; i < rotationsCount; i++)
            {
                int elementToTake = inputData[indxToTake];
                inputData.RemoveAt(indxToTake);

                if (direction == "left")
                {
                    inputData.Add(elementToTake);
                    continue;
                }

                inputData.Insert(0, elementToTake);
            }           
        }

        private static bool IsValidIndx(List<int> inputData, int indx)        
        {           
            return indx >= 0 && indx < inputData.Count;
        }

        private static List<int> ReadInput()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}
