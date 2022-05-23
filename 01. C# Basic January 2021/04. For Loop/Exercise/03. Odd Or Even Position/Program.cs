using System;

namespace _03.OddOrEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double sumOdd = 0.00;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double sumEven = 0.00;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double currentNumber = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    sumEven += currentNumber;

                    if (currentNumber < evenMin)
                    {
                        evenMin = currentNumber;
                    }

                    if (currentNumber > evenMax)
                    {
                        evenMax = currentNumber;
                    }
                }
                else 
                {
                    sumOdd += currentNumber;

                    if (currentNumber < oddMin)
                    {
                        oddMin = currentNumber;
                    }

                    if (currentNumber > oddMax)
                    {
                        oddMax = currentNumber;
                    }
                }
            }

            Console.WriteLine($"OddSum={sumOdd:f2},");
            if (sumOdd == 0)
            {
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
            }
            Console.WriteLine($"EvenSum={sumEven:f2},");
            if (sumEven == 0)
            {
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
        }
    }
}
