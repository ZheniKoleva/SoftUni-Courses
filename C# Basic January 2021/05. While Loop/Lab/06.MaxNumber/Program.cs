using System;

namespace _06.MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int numMax = int.MinValue;

            while (input != "Stop")
            {
                int currentNumber = int.Parse(input);

                if (currentNumber > numMax)
                {
                    numMax = currentNumber;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{numMax}");
        }
    }
}
