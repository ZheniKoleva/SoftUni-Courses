using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightCarsCount = int.Parse(Console.ReadLine());
            
            Queue<string> carsInCrossroad = new Queue<string>();
            int carsPassed = 0;

            string line;

            while ((line = Console.ReadLine()) != "end")
            {
                if (line == "green")
                {
                    for (int i = 0; i < greenLightCarsCount; i++)
                    {
                        if (!carsInCrossroad.Any())
                        {
                            break;
                        }

                        Console.WriteLine($"{carsInCrossroad.Dequeue()} passed!");
                        carsPassed++;
                    }

                    continue;
                }

                carsInCrossroad.Enqueue(line);
            }

            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
