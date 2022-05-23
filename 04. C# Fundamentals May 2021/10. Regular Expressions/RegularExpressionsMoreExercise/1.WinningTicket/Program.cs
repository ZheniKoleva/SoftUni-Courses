using System;
using System.Text.RegularExpressions;

namespace _1.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"((?<main>[\$|@|\^|#])\k<main>{5,9})";

            //string pattern = @"[\$|\@|\^|#]{6,10}"; //90/100

            string[] tickets = Console.ReadLine()
                .Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");                    
                    continue;
                }

                string left = ticket.Substring(0, 10);
                string right = ticket.Substring(10, 10);

                Match resultLeft = Regex.Match(left, pattern);
                Match resultRight = Regex.Match(right, pattern);

                if (!resultLeft.Success || !resultRight.Success)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }

                char leftChar = char.Parse(resultLeft.Value[0].ToString());
                char rightChar = char.Parse(resultRight.Value[0].ToString());

                if (!leftChar.Equals(rightChar))
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }

                if (resultLeft.Length == 10 && resultRight.Length == 10)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {resultLeft.Length}{leftChar} Jackpot!");
                }
                else
                {
                    int minLenght = resultLeft.Length <= resultRight.Length ? resultLeft.Length : resultRight.Length;

                    Console.WriteLine($"ticket \"{ticket}\" - {minLenght}{leftChar}");
                }

            }
        }
    }
}
