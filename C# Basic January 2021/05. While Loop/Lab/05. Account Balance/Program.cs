using System;

namespace _05.AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string payment = Console.ReadLine();
            double sum = 0.00;

            while (payment != "NoMoreMoney")
            {
                double currentSum = double.Parse(payment);
                if (currentSum < 0 )
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                sum += currentSum;
                Console.WriteLine($"Increase: {currentSum:f2}");
                payment = Console.ReadLine();
            }

            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
