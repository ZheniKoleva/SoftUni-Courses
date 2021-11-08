using System;

namespace _02.EqualSumsEvenOddPosition
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

                string currentNum = digit.ToString();

                for (int index = 0; index < currentNum.Length; index++)
                {
                    if (index % 2 == 0)
                    {
                        sumEven += int.Parse(currentNum[index].ToString());
                    }
                    else 
                    {
                        sumOdd += int.Parse(currentNum[index].ToString());
                    }
                    
                }

                if (sumEven == sumOdd)
                {
                    Console.Write($"{currentNum} ");
                }
                
            }
        }
    }
}
