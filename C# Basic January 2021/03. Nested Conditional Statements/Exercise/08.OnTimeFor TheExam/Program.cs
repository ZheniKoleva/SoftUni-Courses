using System;

namespace _08.OnTimeFor_TheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minutesExam = int.Parse(Console.ReadLine());
            int hourArrival = int.Parse(Console.ReadLine());
            int minutesArrival = int.Parse(Console.ReadLine());

            int timeExam = hourExam * 60 + minutesExam;
            int timeArrrival = hourArrival * 60 + minutesArrival;

            int difference = timeExam - timeArrrival;

            if (timeExam >= timeArrrival && difference <= 30)
            {
                Console.WriteLine("On time");
                if (difference != 0)
                {
                    Console.WriteLine($"{difference} minutes before the start");
                }
            }
            else if (timeExam > timeArrrival && difference > 30)
            {
                Console.WriteLine("Early");
                if (difference < 60)
                {
                    Console.WriteLine($"{difference} minutes before the start");
                }
                else if (difference >= 60)
                {
                    int hour = difference / 60;
                    int minutes = difference % 60;
                    Console.WriteLine($"{hour}:{minutes:d2} hours before the start");
                }
            }
            else if (timeArrrival > timeExam)
            {
                Console.WriteLine("Late");
                difference = timeArrrival - timeExam;
                if (difference < 60)
                {
                    Console.WriteLine($"{difference} minutes after the start");
                }
                else if (difference >= 60)
                {
                    int hour = difference / 60;
                    int minutes = difference % 60;
                    Console.WriteLine($"{hour}:{minutes:d2} hours after the start");
                }
            }
        }
    }
}
