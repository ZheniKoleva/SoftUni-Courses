using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputData = ReadInput();
            
            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] tokens = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                switch (command)
                {
                    case "Delete":
                        int elementToDelete = int.Parse(tokens[1]);
                        inputData.RemoveAll(x => x == elementToDelete);
                        break;

                    case "Insert":
                        int elementToInsert = int.Parse(tokens[1]);
                        int indxToInsert = int.Parse(tokens[2]);
                        inputData.Insert(indxToInsert, elementToInsert);
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', inputData));

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

