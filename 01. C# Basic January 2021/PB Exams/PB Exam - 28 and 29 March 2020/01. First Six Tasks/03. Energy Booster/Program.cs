using System;

namespace _03.EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            string gelFruit = Console.ReadLine().ToLower();
            string setSize = Console.ReadLine().ToLower();
            int setsOrdered = int.Parse(Console.ReadLine());

            const int smallSetCount = 2;
            const int bigSetCount = 5;
            double pricePerSet = 0.00;
            
            switch (gelFruit)
            {
                case "watermelon":
                    switch (setSize)
                    {
                        case "small":
                            pricePerSet = 56.00 * smallSetCount;
                            break;
                        
                        case "big":
                            pricePerSet = 28.70 * bigSetCount;
                            break;
                    }
                    break;

                case "mango":
                    switch (setSize)
                    {
                        case "small":
                            pricePerSet = 36.66 * smallSetCount;
                            break;

                        case "big":
                            pricePerSet = 19.60 * bigSetCount;
                            break;
                    }
                    break;

                case "pineapple":
                    switch (setSize)
                    {
                        case "small":
                            pricePerSet = 42.10 * smallSetCount;
                            break;

                        case "big":
                            pricePerSet = 24.80 * bigSetCount;
                            break;
                    }
                    break;

                case "raspberry":
                    switch (setSize)
                    {
                        case "small":
                            pricePerSet = 20.00 * smallSetCount;
                            break;

                        case "big":
                            pricePerSet = 15.20 * bigSetCount;
                            break;
                    }
                    break;                
                
            }

            double finalPrice = setsOrdered * pricePerSet;

            if (finalPrice >= 400 && finalPrice <= 1000)
            {
                finalPrice -= finalPrice * 0.15;
            }
            else if (finalPrice > 1000)
            {
                finalPrice /= 2;
            }

            Console.WriteLine($"{finalPrice:f2} lv.");

        }
    }
}
