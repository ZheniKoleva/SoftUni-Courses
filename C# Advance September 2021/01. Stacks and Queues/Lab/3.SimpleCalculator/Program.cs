using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {  
            Stack<string> calculated = new Stack<string>(ReadData());

            while (calculated.Count > 1)
            {
                int firstNum = int.Parse(calculated.Pop());
                string action = calculated.Pop();
                int secondNum = int.Parse(calculated.Pop());

                int currentResult = action.Equals("+") 
                    ? (firstNum + secondNum) 
                    : (firstNum - secondNum);

                calculated.Push(currentResult.ToString());
            }

            Console.WriteLine(calculated.Pop());
        }

        private static IEnumerable<string> ReadData()
        {
            return Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Reverse();               
        }
    }
}
