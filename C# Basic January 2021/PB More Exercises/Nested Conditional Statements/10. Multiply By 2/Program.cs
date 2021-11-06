using System;

namespace _10._MultiplyBy2
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
                                  
            while (number >= 0)
            {                
                Console.WriteLine($"Result: {(number * 2):f2}");
                number = double.Parse(Console.ReadLine());
                if (number < 0)
                {
                    Console.WriteLine("Negative number!");
                }
            }
        }
    }
}
