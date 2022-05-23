using System;

namespace _03._DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositedAmount = double.Parse(Console.ReadLine());
            int depositTerm = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());

            double interestAmountPerYear = depositedAmount * (interest / 100);
            double interestAmountPerMonth = interestAmountPerYear / 12;

            double sum = depositedAmount + (depositTerm * interestAmountPerMonth);
            Console.WriteLine(sum);
        }
    }
}
