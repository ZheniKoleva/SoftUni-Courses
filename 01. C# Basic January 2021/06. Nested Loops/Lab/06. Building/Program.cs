using System;

namespace _06.Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floorsCount = int.Parse(Console.ReadLine());
            int roomsCount = int.Parse(Console.ReadLine());

            for (int floor = floorsCount; floor > 0; floor--)
            {
                for (int room = 0; room < roomsCount; room++)
                {
                    if (floor == floorsCount || floorsCount == 1)
                    {
                        Console.Write($"L{floor}{room} ");
                    }
                    else if (floor % 2 == 0)
                    {
                        Console.Write($"O{floor}{room} ");
                    }
                    else if (floor % 2 != 0)
                    {
                        Console.Write($"A{floor}{room} ");
                    }
                }

                Console.WriteLine();
            }

        }
    }
}
