using System;
using System.Collections.Generic;

namespace _06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            byte linesCount = byte.Parse(Console.ReadLine());

            char previousBracket = '\0';
            bool isBalanced = true;            

            for (int i = 0; i < linesCount; i++)
            {
                string input = Console.ReadLine();
                
                bool isBracket = input == "(" || input == ")";              
               
                if (!isBracket)
                {
                    continue;
                }               

                if (previousBracket == '\0' && input == "(")
                {
                    previousBracket = input[0];                    
                    continue;
                }
                else if (previousBracket == '\0' && input == ")")
                { 
                    isBalanced = false;                    
                    break;
                }

                if (previousBracket == '(' && input == ")")
                {
                    previousBracket = '\0';                    
                }
                else
                {
                    isBalanced = false;                    
                    break;
                }

            }

            if (!isBalanced || previousBracket == '(')
            {
                Console.WriteLine("UNBALANCED");
            }
            else 
            {
                Console.WriteLine("BALANCED");
            }
          
           
        }
    }
}
