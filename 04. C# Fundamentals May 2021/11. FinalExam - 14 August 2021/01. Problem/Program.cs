using System;

namespace _01._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] data = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = data[0];

                switch (command)
                {
                    case "Translate":
                        char symbol = char.Parse(data[1]);
                        char replacement = char.Parse(data[2]);

                        input = input.Replace(symbol, replacement);
                        Console.WriteLine(input);
                        break;

                    case "Includes":
                        string searched = data[1];
                        
                        Console.WriteLine(input.Contains(searched) ? "True" : "False");
                        break;

                    case "Start":
                        string startWith = data[1];

                        Console.WriteLine(input.StartsWith(startWith) ? "True" : "False");
                        break;

                    case "Lowercase":
                        input = input.ToLower();

                        Console.WriteLine(input);
                        break;

                    case "FindIndex":
                        char lastChar = char.Parse(data[1]);

                        Console.WriteLine(input.LastIndexOf(lastChar));
                        break;

                    case "Remove":
                        int startIndx = int.Parse(data[1]);
                        int count = int.Parse(data[2]);

                        input = input.Remove(startIndx, count);
                        Console.WriteLine(input);
                        break;
                }

                line = Console.ReadLine();
            }

        }
    }
}
