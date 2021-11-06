using System;

namespace _02.EqualSumsEvenOddPosition2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int digit = num1; digit <= num2; digit++)
            {
                int sumEven = 0;
                int sumOdd = 0;
                int currentNum = digit;

                for (int position = 0; position < 6; position++)
                {
                    
                    if (position % 2 == 0)
                    {
                        sumEven += currentNum % 10;
                    }
                    else
                    {
                        sumOdd += currentNum % 10;
                    }

                    currentNum = currentNum / 10;
                }


                if (sumEven == sumOdd)
                {
                    Console.Write($"{digit} ");
                }
                
            }
        }
    }
}
