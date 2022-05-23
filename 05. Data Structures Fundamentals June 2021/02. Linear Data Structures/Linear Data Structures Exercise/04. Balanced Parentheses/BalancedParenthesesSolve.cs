namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {        

        public bool AreBalanced(string parentheses)
        {
            Stack<char> brackets = new Stack<char>();

            for (int i = 0; i < parentheses.Length; i++)
            {
                if (brackets.Count == 0)
                {
                    brackets.Push(parentheses[i]);                    
                    continue;
                }

                char topBracket = brackets.Peek();

                if (topBracket.Equals('{') && parentheses[i].Equals('}')
                    || topBracket.Equals('[') && parentheses[i].Equals(']')
                    || topBracket.Equals('(') && parentheses[i].Equals(')'))
                {
                    brackets.Pop();                   
                }
                else
                {
                    brackets.Push(parentheses[i]);                    
                }
            }

            if (brackets.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}
