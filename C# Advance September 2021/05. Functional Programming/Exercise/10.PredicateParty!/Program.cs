using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();           

            string command;

            while ((command = Console.ReadLine()) != "Party!")
            {
                ExtractData(command, out string operation, out string filter, out string condition);

                Predicate<string> applyFilter = GetFilterCondition(filter, condition);

                if (operation.Equals("Remove"))
                {
                    guests.RemoveAll(applyFilter);
                }
                else if(operation.Equals("Double"))
                {
                    List<string> guestsToDouble = guests.FindAll(applyFilter); 

                    foreach (var guest in guestsToDouble)
                    {
                        guests.Insert(guests.IndexOf(guest) + 1, guest);
                    }
                }
                
            }

            Console.WriteLine(guests.Count > 0
               ? $"{string.Join(", ", guests)} are going to the party!"
               : "Nobody is going to the party!");
        }

        private static Predicate<string> GetFilterCondition(string filter, string condition)
        {
            return filter switch
            {
                "StartsWith" => name => name.StartsWith(condition),
                "EndsWith" => name => name.EndsWith(condition),
                "Length" => name => name.Length == int.Parse(condition),
                _ => null,
            };
        }

        private static void ExtractData(string command, out string operation, out string filter, out string condition)
        {
            string[] commandData = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            operation = commandData[0];
            filter = commandData[1];
            condition = commandData[2];
        }
    }
}
