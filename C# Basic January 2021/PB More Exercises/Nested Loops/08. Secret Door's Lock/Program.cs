using System;

namespace _08.SecretDoor_sLock
{
    class Program
    {
        static void Main(string[] args)
        {
            int end100 = int.Parse(Console.ReadLine());
            int end10 = int.Parse(Console.ReadLine());
            int end1 = int.Parse(Console.ReadLine());


            for (int i = 2; i <= end100; i += 2)
            {
                for (int j = 2; j <= end10; j++)
                {
                    for (int k = 2; k <= end1; k += 2)
                    {
                        if (j == 2 || j == 3)
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                        else if (j % 2 == 0)
                        {
                            continue;
                        }
                        else if (j % 3 != 0)
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
    }
}
