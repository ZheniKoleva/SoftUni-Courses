using System;

namespace _03.AluminumJoinery
{
    class Program
    {
        static void Main(string[] args)
        {
            int joineryCount = int.Parse(Console.ReadLine());
            string joineryType = Console.ReadLine();
            string delivery = Console.ReadLine();

            double price = 0.00;

            if (joineryCount < 10)
            {
                Console.WriteLine("Invalid order");
                return;
            }
            
            switch (joineryType)
            {
                case "90X130":
                    price = 110;
                    if (joineryCount > 60)
                    {
                        price -= price * 0.08;
                    }
                    else if (joineryCount > 30)
                    {
                        price -= price * 0.05;
                    }

                    break;

                case "100X150":
                    price = 140;
                    if (joineryCount > 80)
                    {
                        price -= price * 0.10;
                    }
                    else if (joineryCount > 40)
                    {
                        price -= price * 0.06;
                    }

                    break;

                case "130X180":
                    price = 190;
                    if (joineryCount > 50)
                    {
                        price -= price * 0.12;
                    }
                    else if (joineryCount > 20)
                    {
                        price -= price * 0.07;
                    }

                    break;

                case "200X300":
                    price = 250;
                    if (joineryCount > 50)
                    {
                        price -= price * 0.14;
                    }
                    else if (joineryCount > 25)
                    {
                        price -= price * 0.09;
                    }

                    break;                
            }

            double totalPrice = price * joineryCount;

            if (delivery == "With delivery")
            {
                totalPrice += 60.00;
            }

            if (joineryCount > 99)
            {
                totalPrice -= totalPrice * 0.04;
            }

            Console.WriteLine($"{totalPrice:f2} BGN");

        }
    }
}
