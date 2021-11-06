using System;

namespace _06.OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            double result = 0.00;

            if (operation == '+' || operation == '-' || operation == '*')
            {
                switch (operation)
                {
                    case '+':
                        result = number1 + number2;                       
                        break;
                    case '-':
                        result = number1 - number2;                        
                        break;
                    case '*':
                        result = number1 * number2;
                        break;
                }
                string resultIs = result % 2 == 0 ? "even" : "odd";
                Console.WriteLine($"{number1} {operation} {number2} = {result} - {resultIs}");
            }
            else if (operation == '/' || operation == '%')
            {
                if (number2 == 0)
                {
                    Console.WriteLine($"Cannot divide {number1} by zero");
                }
                else
                {
                    switch (operation)
                    {
                        case '/':
                            result = (double)number1 / number2 ;
                            Console.WriteLine($"{number1} {operation} {number2} = {result:f2}");
                            break;
                        case '%':
                            result = number1 % number2;
                            Console.WriteLine($"{number1} {operation} {number2} = {result}");
                            break;
                    }
            } 
                }                
        }
    }
}
