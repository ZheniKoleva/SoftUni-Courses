using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = ReadInput();
            int maxCapasity = int.Parse(Console.ReadLine());

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] tokens = line
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {
                    int wagonToAdd = int.Parse(tokens[1]);
                    wagons.Add(wagonToAdd);
                }
                else
                {
                    int passengerToAdd = int.Parse(tokens[0]);
                    //wagons = AddPassangers(wagons, maxCapasity, passengerToAdd);
                    AddPassangers(wagons, maxCapasity, passengerToAdd);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', wagons));

        }

        private static void AddPassangers(List<int> wagons, int maxCapasity, int passengerToAdd)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                int currentPassengers = wagons[i];
                bool hasSpace = currentPassengers + passengerToAdd <= maxCapasity;

                if (hasSpace)
                {
                    wagons[i] += passengerToAdd;
                    break;
                }                
            }

            //return wagons;
            
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
