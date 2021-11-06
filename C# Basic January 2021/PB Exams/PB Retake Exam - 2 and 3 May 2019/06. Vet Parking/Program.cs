using System;

namespace _06.VetParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysCount = int.Parse(Console.ReadLine());
            int hoursCount = int.Parse(Console.ReadLine());

            const double hourTaxEven = 1.25;
            const double hourTaxOdd = 2.50;
            const double hourTaxAllcases = 1.00;

            double totalTaxAllDays = 0.00;

            for (int day = 1; day <= daysCount; day++)
            {
                double taxCurrentDay = 0.00;

                for (int hour = 1; hour <= hoursCount; hour++)
                {                   

                    if (day % 2 == 0 && hour % 2 != 0)
                    {
                        taxCurrentDay += hourTaxOdd;
                    }
                    else if (day % 2 != 0 && hour % 2 == 0)
                    {
                        taxCurrentDay += hourTaxEven;
                    }
                    else
                    {
                        taxCurrentDay += hourTaxAllcases;
                    }
                }
                Console.WriteLine($"Day: {day} - {taxCurrentDay:f2} leva");
                totalTaxAllDays += taxCurrentDay;
            }

            Console.WriteLine($"Total: {totalTaxAllDays:f2} leva");
        }
    }
}


