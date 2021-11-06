using System;

namespace _07.MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int numMin = int.MaxValue;

            while (input != "Stop")
            {
                int currentNumber = int.Parse(input);

                if (currentNumber < numMin)
                {
                    numMin = currentNumber;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{numMin}");
        }
    }
}
