using System;

namespace _09._YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double squareToGreen = double.Parse(Console.ReadLine());

            double price = squareToGreen * 7.61;
            double discount = price * 0.18;
            double endPrice = price - discount;

            Console.WriteLine($"The final price is: {endPrice} lv.");
            Console.WriteLine("The discount is: {0} lv.", discount);
        }
    }
}
