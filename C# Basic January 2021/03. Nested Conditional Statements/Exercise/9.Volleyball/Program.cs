using System;

namespace _9.Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string leapOrNot = Console.ReadLine();
            int holidayDays = int.Parse(Console.ReadLine());
            int weekendsTravel = int.Parse(Console.ReadLine());

            int weekendsInSofia = 48 - weekendsTravel;
            double playsInSofia = (weekendsInSofia * 3.0 / 4) + (holidayDays * 2.0 / 3);
            double playsInNativeTown = weekendsTravel;

            double playsTotal = 0.00;

            if (leapOrNot == "leap")
            {
                playsTotal = (playsInSofia + playsInNativeTown) * 1.15;
            }
            else if (leapOrNot == "normal")
            {
                playsTotal = playsInSofia + playsInNativeTown;
            }

            Console.WriteLine(Math.Floor(playsTotal));
        }
    }
}
