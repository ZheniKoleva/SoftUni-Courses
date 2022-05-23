using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();
            
            ReviseGuests(vipGuests, regularGuests);

            Console.WriteLine(vipGuests.Count + regularGuests.Count);
            PrintGuests(vipGuests);
            PrintGuests(regularGuests);            
        }

        private static void ReviseGuests(HashSet<string> vipGuests, HashSet<string> regularGuests)
        {
            bool isPartyStarted = false;
            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                if (line.Equals("PARTY"))
                {
                    isPartyStarted = true;
                }

                if (!isPartyStarted)
                {
                    _ = char.IsDigit(line[0])
                        ? vipGuests.Add(line)
                        : regularGuests.Add(line);
                }
                else
                {
                    _ = char.IsDigit(line[0])
                        ? vipGuests.Remove(line)
                        : regularGuests.Remove(line);
                }
            }
        }

        private static void PrintGuests(HashSet<string> guests)
        {
            if (guests.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, guests));
            }
        }
    }
}
