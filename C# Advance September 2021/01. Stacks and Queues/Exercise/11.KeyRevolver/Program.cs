using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(ReadData());
            Queue<int> locks = new Queue<int>(ReadData());
            int profit = int.Parse(Console.ReadLine());

            int bulletsShot = 0;
            int bulletsInBarrel = gunBarrelSize;

            while (bullets.Any() && locks.Any())
            {
                int currentLock = locks.Peek();
                int currentBullet = bullets.Pop();
                bulletsShot++;
                bulletsInBarrel--;

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");                    
                }

                if (bulletsInBarrel == 0 && bullets.Any())
                {
                    bulletsInBarrel = gunBarrelSize;
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                profit -= bulletsShot * bulletPrice;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${profit}");
            }

        }

        private static IEnumerable<int> ReadData()
        {
            return Console.ReadLine()
                          .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse);
        }
    }
}
