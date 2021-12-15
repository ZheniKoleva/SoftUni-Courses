using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(ReadData());
            Stack<int> plates = new Stack<int>(ReadData());

            int wastedFood = 0;

            while (guests.Any() && plates.Any())
            {
                int currentGuest = guests.Peek();

                while (currentGuest > 0 && plates.Count > 0)
                {
                    int currentFood = plates.Pop();

                    if (currentFood >= currentGuest)
                    {
                        wastedFood += (currentFood - currentGuest);
                        guests.Dequeue();
                        break;
                    }

                    currentGuest -= currentFood;
                }
                
            }

            Console.WriteLine(guests.Any()
                ? $"Guests: {string.Join(' ', guests)}"
                : $"Plates: {string.Join(' ', plates)}");
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }

        private static int[] ReadData()
        {
            return Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
        }

    }
}

