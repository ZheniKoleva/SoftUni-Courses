using System;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> brackets = new Stack<int>();

            for (int indx = 0; indx < expression.Length; indx++)
            {
                if (expression[indx].Equals('('))
                {
                    brackets.Push(indx);
                }

                if (expression[indx].Equals(')'))
                {
                    int startIndx = brackets.Pop();

                    for (int i = startIndx; i <= indx; i++)
                    {
                        Console.Write(expression[i]);
                    }

                    Console.WriteLine();

                    // second solution
                    //int count = indx - startIndx + 1;
                    //Console.WriteLine(expression.Substring(startIndx, count)); 
                }
            }
        }
    }
}
