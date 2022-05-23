using System;

namespace _07._FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int magnoliaCount = int.Parse(Console.ReadLine());
            int hyacinthCount = int.Parse(Console.ReadLine());
            int roseCount = int.Parse(Console.ReadLine());
            int cactusCount = int.Parse(Console.ReadLine());
            double presentPrice = double.Parse(Console.ReadLine());

            double profit = (magnoliaCount * 3.25 + hyacinthCount * 4.0 + roseCount * 3.50 +
                cactusCount * 8.0) * 0.95;

            if (profit < presentPrice)
            {
                Console.WriteLine("She will have to borrow {0} leva.", Math.Ceiling(presentPrice - profit));
            }
            else
            {
                
                Console.WriteLine("She is left with {0} leva.", Math.Floor(profit - presentPrice));
            }
            
        }
    }
}
