using System;

namespace _05.ChallengeTheWedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int menCount = int.Parse(Console.ReadLine());
            int womenCount = int.Parse(Console.ReadLine());
            int tablesMaxCount = int.Parse(Console.ReadLine());

            int tablesTaken = 0;
            bool flag = false;

            for (int men = 1; men <= menCount; men++)
            {
                for (int women = 1; women <= womenCount; women++)
                {
                    Console.Write($"({men} <-> {women}) ");
                    tablesTaken++;

                    if (tablesTaken >= tablesMaxCount)
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    break;
                }
            }
        }
    }
}
