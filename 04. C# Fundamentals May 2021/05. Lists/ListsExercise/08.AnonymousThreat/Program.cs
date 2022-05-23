using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = ReadInput();

            string line = Console.ReadLine();

            while (line != "3:1")
            {
                string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                switch (command)
                {
                    case "merge":
                        int startIndx = int.Parse(tokens[1]);
                        int endIndx = int.Parse(tokens[2]);

                        if (startIndx >= input.Count || endIndx < 0)
                        {
                            break;
                        }

                        if (startIndx < 0)
                        {
                            startIndx = 0;
                        }                       

                        if (endIndx >= input.Count)
                        {
                            endIndx = input.Count - 1;
                        }

                        MergeList(input, startIndx, endIndx);
                        input.TrimExcess();
                        break;

                    case "divide":
                        int indx = int.Parse(tokens[1]); // не се проверява валидност, понеже по условие е винаги валиден
                        int partitions = int.Parse(tokens[2]); // 0-100

                        if (partitions > 0)
                        {
                            string elementToDivide = input[indx];
                            input.RemoveAt(indx);
                            string[] divided = DivideElement(elementToDivide, partitions);
                            input.InsertRange(indx, divided);
                        }
                        
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', input));

        }

        private static string[] DivideElement(string elementToDivide, int partitions)
        {
            int symbolsInPart = elementToDivide.Length / partitions;

            string[] divided = new string[partitions];

            for (int i = 0; i < partitions; i++)
            {
                string subString = elementToDivide.Substring(0, symbolsInPart);
                elementToDivide = elementToDivide.Remove(0, symbolsInPart);

                if (elementToDivide.Length < symbolsInPart)
                {
                    subString += elementToDivide;
                }

                divided[i] = subString;
            }

            return divided;
        }

        private static void MergeList(List<string> input, int startIndx, int endIndx)
        {
            StringBuilder merged = new StringBuilder();

            for (int i = startIndx; i <= endIndx; i++)
            {
                merged.Append(input[i]);
            }

            input.RemoveRange(startIndx, endIndx - startIndx + 1);
            input.Insert(startIndx, merged.ToString());            
        }

        private static List<string> ReadInput()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }
    }
}
