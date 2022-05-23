using System;
using System.Collections.Generic;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            List<string> guestsList = new List<string>();

            for (int i = 0; i < linesCount; i++)
            {
                string command = Console.ReadLine();
                string[] tokens = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];

                if (command.Contains("is going!"))
                {
                    if (guestsList.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                       continue;
                    }

                    guestsList.Add(name);
                }
                else
                {
                    bool isRemoved = guestsList.Remove(name);

                    if (!isRemoved)
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                   
                }
                
            }

            Console.WriteLine(string.Join(Environment.NewLine, guestsList));
        }
    }
}
