using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double lightsaberCount = Math.Ceiling(studentsCount * 1.10);
            int beltsForFree = studentsCount / 6;

            double totalPrice = (lightsaberCount * lightsaberPrice)
                + (robePrice * studentsCount) + (beltPrice * (studentsCount - beltsForFree));

            if (budget >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                double moneyNeeded = totalPrice - budget;
                Console.WriteLine($"John will need {moneyNeeded:f2}lv more.");
            }

        }
    }
}
