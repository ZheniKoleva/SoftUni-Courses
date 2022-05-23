using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> initialDrumSet = ReadInput();

            List<int> currentCondition = initialDrumSet.ToList();            

            string line = Console.ReadLine();

            while (line != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(line);

                for (int i = 0; i < currentCondition.Count; i++)
                {
                    currentCondition[i] -= hitPower;

                    if (currentCondition[i] <= 0)
                    {
                        int initialQuality = initialDrumSet[i];
                        double drumPrice = initialQuality * 3;

                        if (drumPrice > savings)
                        {                            
                            initialDrumSet.RemoveAt(i);
                            currentCondition.RemoveAt(i);
                            i--;
                            continue;
                        }

                        savings -= drumPrice;
                        currentCondition[i] = initialQuality;                       
                    }
                }
               
                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', currentCondition));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }

        private static List<int> ReadInput()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}
