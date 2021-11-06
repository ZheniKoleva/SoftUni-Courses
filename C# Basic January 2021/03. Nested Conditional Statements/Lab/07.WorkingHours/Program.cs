using System;

namespace _07.WorkingHours
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string dayOfWeek = Console.ReadLine().ToLower();

            switch (dayOfWeek)
            {
                case "monday":
                case "tuesday":
                case "wednesday":
                case "thursday":
                case "friday":
                case "saturday":
                    if (hour >= 10 && hour <= 18)
                    {
                        Console.WriteLine("open");
                    }
                    else
                    {
                        Console.WriteLine("closed");
                    }
                    break;

                case "sunday":
                    Console.WriteLine("closed");
                    break;

            }
        }
    }
}
