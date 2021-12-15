using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, char> combinations = new Dictionary<char, char>
            {
                { '(', ')'},
                { '[', ']'},
                { '{','}'}
            };

            string input = Console.ReadLine();

            bool isBalanced = true;
            Stack<char> openBrackets = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input.Length % 2 == 1)
                {
                    isBalanced = false;
                    break;
                }

                if (combinations.ContainsKey(input[i]))
                {
                    openBrackets.Push(input[i]);
                    continue;
                }

                char closeBracket = input[i];
                char lastOpenBracket = openBrackets.Peek();

                if (!combinations[lastOpenBracket].Equals(closeBracket))
                {
                    isBalanced = false;
                    break;
                }

                openBrackets.Pop();
            }

            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}
