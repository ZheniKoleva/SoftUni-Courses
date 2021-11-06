using System;

namespace _11.CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());

            double moneySaved = 0.00;
            double moneyGiven = 10.00;
            int toysCount = 0;

            for (int birthday = 1; birthday <= age; birthday++)
            {
                if (birthday % 2 == 0)
                {
                    moneySaved += moneyGiven;
                    moneySaved--;
                    moneyGiven += 10.00;
                }
                else
                {
                    toysCount++;
                }                
            }

            double toysMoneyTotal = toysCount * toysPrice;
            moneySaved += toysMoneyTotal;

            if (moneySaved >= washingMachinePrice)
            {
                double moneyLeft = moneySaved - washingMachinePrice;
                Console.WriteLine($"Yes! {moneyLeft:f2}");
            }
            else
            {
                double moneyNeed = washingMachinePrice - moneySaved;
                Console.WriteLine($"No! {moneyNeed:f2}");
            }
        }
    }
}
