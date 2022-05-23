using System;

namespace _08.EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum1Plus2 = 0;
            int difference = 0;

            for (int i = 0; i < n; i++)
            {
                int number1 = int.Parse(Console.ReadLine());
                int number2 = int.Parse(Console.ReadLine());
                int currentSum = number1 + number2;

                if (i == 0 || currentSum == sum1Plus2)
                {
                    sum1Plus2 = currentSum;                    
                }               
                else if (currentSum > sum1Plus2)
                {
                    difference = currentSum - sum1Plus2);
                }
            }

            if (sum1Plus2 == difference)
            {
                Console.WriteLine($"Yes, value = {sum1Plus2}");
            }
            else if (sum1Plus2 != difference)
            {
                Console.WriteLine($"No, maxdiff = {difference}");
            }           
        }
    }
}
