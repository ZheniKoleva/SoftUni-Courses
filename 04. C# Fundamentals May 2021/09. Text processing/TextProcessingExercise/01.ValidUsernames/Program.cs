using System;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var userName in userNames)
            {
                if (IsValidUserName(userName))
                {
                    Console.WriteLine(userName);
                }
            }
        }

        private static bool IsValidUserName(string userName)
        {
            return HasValidLenght(userName) && HasValidSymbols(userName);
        }

        private static bool HasValidSymbols(string userName)
        {
            foreach (var item in userName)
            {
                if (!(char.IsLetterOrDigit(item)
                    || item.Equals('-')
                    || item.Equals('_')))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool HasValidLenght(string userName, int start = 3, int end = 16)
        {
            return userName.Length >= start && userName.Length <= end;
        }
    }
}
