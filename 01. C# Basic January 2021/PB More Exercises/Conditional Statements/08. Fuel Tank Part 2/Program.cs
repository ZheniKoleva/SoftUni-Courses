using System;

namespace _08._FuelTankPart_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine().ToLower();
            double fuelAmount = double.Parse(Console.ReadLine());
            string clubCardAvailable = Console.ReadLine().ToLower();

            double sumTotal = 0.0;

            if (clubCardAvailable == "yes")
            {
                if (fuelType == "gasoline") sumTotal = fuelAmount * 2.04;               
                else if (fuelType == "diesel") sumTotal = fuelAmount * 2.21;               
                else if (fuelType == "gas") sumTotal = fuelAmount * 0.85;                
            }
            else if (fuelType == "gasoline") sumTotal = fuelAmount * 2.22;            
            else if (fuelType == "diesel") sumTotal = fuelAmount * 2.33;            
            else if (fuelType == "gas") sumTotal = fuelAmount * 0.93;
            if (fuelAmount >= 20 && fuelAmount <= 25)
            {
                if (fuelType == "gasoline") sumTotal = sumTotal * 0.92;
                else if (fuelType == "diesel") sumTotal = sumTotal * 0.92;
                else if (fuelType == "gas") sumTotal = sumTotal * 0.92;                
            }
            else if (fuelAmount > 25)
                if (fuelType == "gasoline") sumTotal = sumTotal * 0.90;
                else if (fuelType == "diesel") sumTotal = sumTotal * 0.90;
                else if (fuelType == "gas") sumTotal = sumTotal * 0.90;
            Console.WriteLine($"{sumTotal:f2} lv.");
            }
    }
}
