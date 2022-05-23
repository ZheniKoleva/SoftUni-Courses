using System;

namespace _01.BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int yearlyTax = int.Parse(Console.ReadLine());

            double sneakers = yearlyTax * 0.60;
            double sportSuit = sneakers * 0.80;
            double ball = sportSuit * 0.25;
            double accesssories = ball * 0.20;

            double totalSum = yearlyTax + sneakers + sportSuit + ball + accesssories;
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
