using System;

namespace _04.EasterShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggsStartQuantity = int.Parse(Console.ReadLine());

            int eggsSold = 0;
            bool flag = false;

            string action = Console.ReadLine();

            while (action != "Close")
            {
                int eggsCount = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case "Buy":
                        if (eggsStartQuantity < eggsCount)
                        {
                            flag = true;
                            break;
                        }
                        eggsStartQuantity -= eggsCount;
                        eggsSold += eggsCount;
                        break;

                    case "Fill":
                        eggsStartQuantity += eggsCount;
                        break;

                }

                if (flag)
                {
                    flag = false;
                    break;
                }
                action = Console.ReadLine();
            }

            if (action == "Close")
            {
                Console.WriteLine("Store is closed!");
                Console.WriteLine($"{eggsSold} eggs sold.");
            }
            else
            {
                Console.WriteLine("Not enough eggs in store!");
                Console.WriteLine($"You can buy only {eggsStartQuantity}.");
            }
        }
    }
}
