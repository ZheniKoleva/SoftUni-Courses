using System;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dayOfWeek = {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday",
            };

            int day = int.Parse(Console.ReadLine());

            if (day < 1 || day > dayOfWeek.Length)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine($"{dayOfWeek[day - 1]}");
            }
        }
    }
}
