using System;

namespace _11.HappyCatParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysCount = int.Parse(Console.ReadLine());
            int hoursCount = int.Parse(Console.ReadLine());

            const double hourOdd = 2.50; 
            const double hourEven = 1.25;
            const double hourAllCase = 1.00;
                       
            double sumAllDays = 0.00;

            for (int day = 1; day <= daysCount; day++)
            {
                double sumForDay = 0.00;

                for (int hour = 1; hour <= hoursCount; hour++)
                {
                    if (day % 2 == 0 && hour % 2 != 0)
                    {
                        sumForDay += hourOdd;
                    }
                    else if (day % 2 != 0 && hour % 2 == 0)
                    {
                        sumForDay += hourEven;
                    }
                    else
                    {
                        sumForDay += hourAllCase;
                    }                    
                    
                }

                Console.WriteLine($"Day: {day} - {sumForDay:f2} leva");
                sumAllDays += sumForDay;
            }

            Console.WriteLine($"Total: {sumAllDays:f2} leva");
        }
    }
}
