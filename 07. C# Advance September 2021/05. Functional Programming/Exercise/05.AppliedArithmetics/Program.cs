using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);                

            string arithmeticOperation;

            while ((arithmeticOperation = Console.ReadLine()) != "end")
            {
                switch (arithmeticOperation)
                {
                    case "add":
                    case "subtract":
                    case "multiply":
                        Func<int, int> operation= GetArithmeticOperation(arithmeticOperation);                        
                        numbers = numbers.Select(operation);
                            break;                        
                    case "print":
                        Action<IEnumerable<int>> print = numbers => Console.WriteLine(string.Join(' ', numbers));
                        print(numbers);
                        break; 
                }
            }
        }

        private static Func<int, int> GetArithmeticOperation(string arithmeticOperation)
        {
            return arithmeticOperation switch
            {
                "add" => x => x += 1,
                "multiply" => x => x *= 2,
                "subtract" => x => x -= 1,
                _ => null,
            };
        }
    }
}
