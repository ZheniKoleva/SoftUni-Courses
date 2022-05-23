using System;

namespace _05._Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int projectHours = int.Parse(Console.ReadLine());
            int daysCount = int.Parse(Console.ReadLine());
            int workerCount = int.Parse(Console.ReadLine());

            double realDays = daysCount * 0.90;
            double workHours = realDays * 8;
            double overtime = daysCount * 2 * workerCount;
            double totalWorkHours = Math.Floor(workHours + overtime);

            if (totalWorkHours >= projectHours)
            {
                Console.WriteLine("Yes!{0} hours left.", (totalWorkHours - projectHours));
            }
            else
            {
                Console.WriteLine("Not enough time!{0} hours needed.", (projectHours - totalWorkHours));
            }
        }
    }
}
