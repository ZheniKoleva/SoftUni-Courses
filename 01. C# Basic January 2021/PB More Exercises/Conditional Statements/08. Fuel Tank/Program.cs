using System;

namespace _08._FuelTank
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine().ToLower();
            double fuelAmount = double.Parse(Console.ReadLine());

            if (fuelType == "diesel" || fuelType == "gasoline" || fuelType == "gas")
            {
                if (fuelAmount >= 25) Console.WriteLine("You have enough {0}.", fuelType);
                else Console.WriteLine("Fill your tank with {0}!", fuelType);               
            }
            else
            {
                Console.WriteLine("Invalid fuel!");
            }
        }
    }
}
