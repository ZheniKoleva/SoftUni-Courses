using System;

namespace _05.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            while (destination != "End")
            {
                double moneyNeeded = double.Parse(Console.ReadLine());
                double moneySaved = 0;

                while (moneySaved < moneyNeeded)
                {
                    moneySaved += double.Parse(Console.ReadLine());
                }

                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();
            }
        }
    }
}
