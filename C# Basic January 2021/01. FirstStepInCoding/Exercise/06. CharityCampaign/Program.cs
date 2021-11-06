using System;

namespace _06._CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfCampaign = int.Parse(Console.ReadLine());
            int numberOfPastryCooks = int.Parse(Console.ReadLine());
            int cakesCountPerDay = int.Parse(Console.ReadLine());
            int wafflesCountPerDay = int.Parse(Console.ReadLine());
            int pancakesCountPerDay = int.Parse(Console.ReadLine());

            const double cakePrice = 45;
            const double wafflesPrice = 5.80;
            const double pancakesPrice = 3.20;

            double sumCakesPerDay = numberOfPastryCooks * cakesCountPerDay * cakePrice;
            double sumWafflesPerDay = numberOfPastryCooks * wafflesCountPerDay * wafflesPrice;
            double sumPancakesPerDay = numberOfPastryCooks * pancakesCountPerDay * pancakesPrice;

            double totalSumCampaigh = (sumCakesPerDay + sumWafflesPerDay + sumPancakesPerDay) * daysOfCampaign;
            double expences = totalSumCampaigh / 8;
            double finalSum = totalSumCampaigh - expences;
            Console.WriteLine(finalSum);
        }
    }
}
