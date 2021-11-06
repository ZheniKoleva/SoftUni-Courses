using System;

namespace _02._SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int freeDays = int.Parse(Console.ReadLine());

            int workDays = 365 - freeDays;
            int totalTimePlay = workDays * 63 + freeDays * 127;
            int hours = (totalTimePlay - 30000) / 60;
            int minutes = (totalTimePlay - 30000) % 60;

            if (totalTimePlay >= 30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine("{0:f0} hours and {1:f0} minutes more for play", hours, minutes);
            }
            else
            {               
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine("{0:f0} hours and {1:f0} minutes less for play",Math.Abs(hours), Math.Abs(minutes));
            }              
        }
    }
}
