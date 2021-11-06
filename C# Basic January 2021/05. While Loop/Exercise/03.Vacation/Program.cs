using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double moneyHave = double.Parse(Console.ReadLine());

            int days = 0;
            int spendCount = 0;

            while (moneyNeeded > moneyHave)
            {
                string action = Console.ReadLine();
                double currentMoney = double.Parse(Console.ReadLine());                
                days++;

                switch (action)
                {
                    case "save":
                        moneyHave += currentMoney;
                        spendCount = 0;
                        break;

                    case "spend":
                        spendCount++;
                        if (currentMoney > moneyHave)
                        {
                            moneyHave = 0;
                            continue;
                            
                        }
                        moneyHave -= currentMoney;
                        break;
                }

                if (spendCount == 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine($"{days}");
                    return;
                }
            }
            Console.WriteLine($"You saved the money for {days} days.");

        }
    }
}
