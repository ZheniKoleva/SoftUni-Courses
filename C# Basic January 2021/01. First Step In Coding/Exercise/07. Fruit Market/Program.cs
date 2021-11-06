using System;

namespace _07._FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberryPrice = double.Parse(Console.ReadLine());
            double bananaAmount = double.Parse(Console.ReadLine());
            double orangeAmount = double.Parse(Console.ReadLine());
            double raspberryAmount = double.Parse(Console.ReadLine());
            double strawberryAmount = double.Parse(Console.ReadLine());

            const double orange = 0.60;
            const double banana = 0.20;

            double raspberryPrice = strawberryPrice / 2;
            double orangePrice = raspberryPrice * orange;
            double bananaPrice = raspberryPrice * banana;

            double strawberrySum = strawberryAmount * strawberryPrice;
            double bananaSum = bananaAmount * bananaPrice;
            double orangeSum = orangeAmount * orangePrice;
            double raspberrySum = raspberryAmount * raspberryPrice;

            double totalSum = strawberrySum + bananaSum + orangeSum + raspberrySum;
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
