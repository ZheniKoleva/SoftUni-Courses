using System;

namespace _02.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videocardsCount = int.Parse(Console.ReadLine());
            int processorsCount = int.Parse(Console.ReadLine());
            int ramCount = int.Parse(Console.ReadLine());

            const double videocardPrice = 250.00;

            double processorPrice = (videocardPrice * videocardsCount) * 0.35;
            double ramPrice = (videocardPrice * videocardsCount) * 0.10;

            double totalSum = (videocardPrice * videocardsCount) + (processorPrice * processorsCount) +
                (ramPrice * ramCount);

            if (videocardsCount > processorsCount)
            {
                totalSum -= totalSum * 0.15;
            }

            double difference = budget - totalSum;

            if (budget >= totalSum)
            {
                Console.WriteLine($"You have {difference:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(difference):f2} leva more!");
            }
        }
    }
}
