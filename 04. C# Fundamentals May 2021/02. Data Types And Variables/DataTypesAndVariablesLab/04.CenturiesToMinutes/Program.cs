using System;

namespace _04.CenturiesToMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            byte centuries = byte.Parse(Console.ReadLine());
            uint years = (uint)(centuries * 100);
            int days = (int)(years * 365.2422);
            long hours = days * 24;
            long min = hours * 60;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {min} minutes");
        }
    }
}
