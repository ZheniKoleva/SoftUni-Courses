using System;

namespace _03.PaintingEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string eggsSize = Console.ReadLine().ToLower();
            string eggsColour = Console.ReadLine().ToLower();
            int lotsCount = int.Parse(Console.ReadLine());

            double lotsPrice = 0.00;

            switch (eggsSize)
            {
                case "large":
                    switch (eggsColour)
                    {
                        case "red":
                            lotsPrice = 16.00;
                            break;

                        case "green":
                            lotsPrice = 12.00;
                            break;

                        case "yellow":
                            lotsPrice = 9.00;
                            break;
                    }
                    break;

                case "medium":
                    switch (eggsColour)
                    {
                        case "red":
                            lotsPrice = 13.00;
                            break;

                        case "green":
                            lotsPrice = 9.00;
                            break;

                        case "yellow":
                            lotsPrice = 7.00;
                            break;
                    }
                    break;

                case "small":
                    switch (eggsColour)
                    {
                        case "red":
                            lotsPrice = 9.00;
                            break;

                        case "green":
                            lotsPrice = 8.00;
                            break;

                        case "yellow":
                            lotsPrice = 5.00;
                            break;
                    }
                    break;                    
            }

            double totalPrice = lotsCount * lotsPrice;
            double expenses = totalPrice * 0.35;
            double finalPrice = totalPrice - expenses;

            Console.WriteLine($"{finalPrice:f2} leva.");
        }
    }
}
