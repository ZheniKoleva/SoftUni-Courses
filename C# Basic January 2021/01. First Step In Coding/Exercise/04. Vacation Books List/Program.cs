using System;

namespace _04._VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPages = int.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            int daysToReadBook = int.Parse(Console.ReadLine());

            double totalHoursToReadBook = numberOfPages / pagesPerHour;
            double hoursPerDay = totalHoursToReadBook / daysToReadBook;
            Console.WriteLine(hoursPerDay);
        }
    }
}
