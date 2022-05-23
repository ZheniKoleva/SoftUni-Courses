using System;

namespace _04.TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupsCount = int.Parse(Console.ReadLine());

            int peopleTotal = 0;
            int musala = 0;
            int monblan = 0;
            int kilimandjaro = 0;
            int k2 = 0;
            int everest = 0;

            for (int groups = 1; groups <= groupsCount; groups++)
            {
                int peopleCount = int.Parse(Console.ReadLine());
                peopleTotal += peopleCount;

                if (peopleCount < 6)
                {
                    musala += peopleCount;
                }
                else if (peopleCount >= 6 && peopleCount < 13)
                {
                    monblan += peopleCount;
                }
                else if (peopleCount >= 13 && peopleCount < 26)
                {
                    kilimandjaro += peopleCount;
                }
                else if (peopleCount >= 26 && peopleCount < 41)
                {
                    k2 += peopleCount;
                }
                else
                {
                    everest += peopleCount;
                }

            }

            double percentMusala = (musala * 100.00) / peopleTotal;
            double percentMonblan = (monblan * 100.00) / peopleTotal;
            double percentKilimandjaro = (kilimandjaro * 100.00) / peopleTotal;
            double percentK2 = (k2 * 100.00) / peopleTotal;
            double percentEverest = (everest * 100.00) / peopleTotal;

            Console.WriteLine($"{percentMusala:f2}%");
            Console.WriteLine($"{percentMonblan:f2}%");
            Console.WriteLine($"{percentKilimandjaro:f2}%");
            Console.WriteLine($"{percentK2:f2}%");
            Console.WriteLine($"{percentEverest:f2}%");
        }
    }
}
