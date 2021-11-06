using System;

namespace _05.GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int turns = int.Parse(Console.ReadLine());

            double result = 0.00;

            int counter0To9 = 0;
            int counter10To19 = 0;
            int counter20To29 = 0;
            int counter30To39 = 0;
            int counter40To50 = 0;           
            int counterInvalid = 0;

            for (int i = 0; i < turns; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 0 || number > 50 )
                {
                    counterInvalid += 1;
                    result /= 2;
                }
                else if (number < 10)
                {
                    counter0To9 += 1;
                    result += number * 0.20;
                }
                else if (number < 20)
                {
                    counter10To19 += 1;
                    result += number * 0.30;
                }
                else if (number < 30)
                {
                    counter20To29 += 1;
                    result += number * 0.40;
                }
                else if (number < 40)
                {
                    counter30To39 += 1;
                    result += 50;
                }
                else if (number <= 50)
                {
                    counter40To50 += 1;
                    result += 100;
                }                
            }
            double percent0To9 = (counter0To9 * 100.00) / turns;
            double percent10To19 = (counter10To19 * 100.00) / turns;
            double percent20To29 = (counter20To29 * 100.00) / turns;
            double percent30To39 = (counter30To39 * 100.00) / turns;
            double percent40To50 = (counter40To50 * 100.00) / turns;
            double percentInvalid = (counterInvalid * 100.00) / turns;

            Console.WriteLine($"{result:f2}");
            Console.WriteLine($"From 0 to 9: {percent0To9:f2}%");
            Console.WriteLine($"From 10 to 19: {percent10To19:f2}%");
            Console.WriteLine($"From 20 to 29: {percent20To29:f2}%");
            Console.WriteLine($"From 30 to 39: {percent30To39:f2}%");
            Console.WriteLine($"From 40 to 50: {percent40To50:f2}%");
            Console.WriteLine($"Invalid numbers: {percentInvalid:f2}%");
        }
    }
}
