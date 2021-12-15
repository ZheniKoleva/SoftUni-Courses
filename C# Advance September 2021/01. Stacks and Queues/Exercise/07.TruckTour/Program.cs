using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();
            ArrangePumps(pumps, pumpsCount);

            int firstPump = -1;
            firstPump = TourPumps(pumps, ref firstPump);

            Console.WriteLine(firstPump);
        }

        private static int TourPumps(Queue<int[]> pumps, ref int firstPump)
        {
            bool rotateAgain = true;           

            while (rotateAgain)
            {
                int petrolHave = 0;
                firstPump++;

                foreach (var pump in pumps)
                {
                    int currentPumpPetrol = pump[0];
                    int distanceToPass = pump[1];

                    petrolHave += currentPumpPetrol;
                    petrolHave -= distanceToPass;

                    if (petrolHave < 0)
                    {
                        pumps.Enqueue(pumps.Dequeue());                        
                        break;
                    }
                }

                if (petrolHave >= 0)
                {
                    rotateAgain = false;
                }
            }

            return firstPump;
        }

        private static void ArrangePumps(Queue<int[]> pumps, int pumpsCount)
        {
            for (int i = 0; i < pumpsCount; i++)
            {
                int[] currentPump = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();

                pumps.Enqueue(currentPump);                     
            }
        }
    }
}
