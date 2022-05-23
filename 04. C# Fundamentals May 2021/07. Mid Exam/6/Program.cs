using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phones = Console.ReadLine()
                 .Split(", ")
                 .ToList();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split(" - ");

                switch (tokens[0])
                {
                    case "Add":
                        if (phones.Contains(tokens[1]))
                        {
                            break;
                        }
                        else
                        {
                            phones.Add(tokens[1]);
                        }
                        break;
                    case "Remove":
                        phones.Remove(tokens[1]);
                        break;
                    case "Bonus phone":
                        string[] phoneData = tokens[1].Split(":");

                        string oldPhone = phoneData[0];
                        string newPhone = phoneData[1];

                        if (phones.Contains(oldPhone))
                        {
                            int index = phones.IndexOf(oldPhone);
                            phones.Insert(index + 1, newPhone);
                        }
                        break;

                    case "Last":
                        if (phones.Contains(tokens[1]))
                        {
                            phones.Remove(tokens[1]);
                            phones.Add(tokens[1]);
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
