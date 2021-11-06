using System;

namespace _08._PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogsCount = int.Parse(Console.ReadLine());
            int animalsCount = int.Parse(Console.ReadLine());

            double sum = dogsCount * 2.50 + animalsCount * 4.0;
            Console.WriteLine($"{sum} lv.");
        }
    }
}
