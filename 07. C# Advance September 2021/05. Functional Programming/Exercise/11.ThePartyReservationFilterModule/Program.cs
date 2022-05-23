using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            Dictionary<string, Predicate<string>> predicates = new Dictionary<string, Predicate<string>>();

            string command;

            while ((command = Console.ReadLine()) != "Print")
            {
                ExtractData(command, out string operation, out string filter, out string condition);

                string predicateKey = filter + '_' + condition;
               
                if (operation.Equals("Remove filter"))
                {
                    predicates.Remove(predicateKey);
                }
                else if (operation.Equals("Add filter"))
                {
                    if (!predicates.ContainsKey(predicateKey))
                    {
                        Predicate<string> filters = GetFilterCondition(filter, condition);
                        predicates.Add(predicateKey, filters);
                    }
                }
            }

            foreach (var (key, predicate) in predicates)
            {
                guests.RemoveAll(predicate);
            }

            Console.WriteLine(string.Join(' ', guests));
        }

        private static Predicate<string> GetFilterCondition(string filter, string condition)
        {
            return filter switch
            {
                "Starts with" => name => name.StartsWith(condition),
                "Ends with" => name => name.EndsWith(condition),
                "Length" => name => name.Length == int.Parse(condition),
                "Contains" => name => name.Contains(condition),
                _ => null,
            };
        }

        private static void ExtractData(string command, out string operation, out string filter, out string condition)
        {
            string[] commandData = command
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

            operation = commandData[0];
            filter = commandData[1];
            condition = commandData[2];
        }
    }
}
