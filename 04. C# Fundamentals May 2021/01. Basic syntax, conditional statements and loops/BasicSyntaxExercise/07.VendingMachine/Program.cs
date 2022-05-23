using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double moneyHave = 0.0;

            while (input != "Start")
            {
                double currentCoins = double.Parse(input);

                if (currentCoins == 0.1 || currentCoins == 0.2 || currentCoins == 0.5
                    || currentCoins == 1.0 || currentCoins == 2.0)
                {
                    moneyHave += currentCoins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {currentCoins}");
                }

                input = Console.ReadLine();
            }

            string product = Console.ReadLine();

            while (product != "End")
            {
                double productPrice = 0.0;

                switch (product)
                {
                    case "Nuts":
                        productPrice = 2.00;
                        break;

                    case "Water":
                        productPrice = 0.70;
                        break;

                    case "Crisps":
                        productPrice = 1.50;
                        break;

                    case "Soda":
                        productPrice = 0.80;
                        break;

                    case "Coke":
                        productPrice = 1.00;
                        break;

                    default:
                        Console.WriteLine("Invalid product");                        
                        break;
                        
                }

                if (moneyHave >= productPrice && productPrice != 0)
                {
                    moneyHave -= productPrice;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else if (moneyHave < productPrice)
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {moneyHave:f2}");

        }
    }
}
