using System;

namespace _10.Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int coins1Lv = int.Parse(Console.ReadLine());
            int coins2Lv = int.Parse(Console.ReadLine());
            int notes5Lv = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            for (int i = 0; i <= coins1Lv; i++)
            {
                for (int j = 0; j <= coins2Lv; j++)
                {
                    for (int k = 0; k <= notes5Lv; k++)
                    {
                        bool isTrue = i * 1 + j * 2 + k * 5 == sum;
                        
                        if (isTrue)
                        {
                            Console.WriteLine($"{i} * 1 lv. + {j} * 2 lv. + {k} * 5 lv. = {sum} lv.");
                        }
                    }
                }
            }
        }
    }
}
