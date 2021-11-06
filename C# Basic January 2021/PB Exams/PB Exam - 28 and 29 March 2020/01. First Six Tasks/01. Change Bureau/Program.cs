using System;

namespace _01.ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoin = int.Parse(Console.ReadLine());
            double chineseYuan = double.Parse(Console.ReadLine());
            double comission = double.Parse(Console.ReadLine());

            const int bitcoinToBgn = 1168;
            const double yuanToUsd = 0.15;
            const double usdToBgn = 1.76;
            const double eurToBgn = 1.95;

            double finalSumInEur = ((bitcoin * bitcoinToBgn) + (chineseYuan * yuanToUsd * usdToBgn)) / eurToBgn;
            finalSumInEur -= (finalSumInEur * comission) / 100;

            Console.WriteLine($"{finalSumInEur:f2}");

        }
    }
}
