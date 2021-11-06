using System;

namespace _01.Back_oThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyInherited = double.Parse(Console.ReadLine());
            int yearBack = int.Parse(Console.ReadLine());
            
            int years = 18;

            for (int i = 1800; i <= yearBack; i++)
            {
                if (i % 2 == 0)
                {
                    moneyInherited -= 12000;
                    years += 1;
                }
                else
                {                    
                    moneyInherited -= 12000 + years * 50;
                    years += 1;
                }
            }
            if (moneyInherited >= 0)
            {                
                Console.WriteLine($"Yes! He will live a carefree life and will have {moneyInherited:f2} dollars left.");
            }
            else
            {                
                Console.WriteLine($"He will need {Math.Abs(moneyInherited):f2} dollars to survive.");
            }
        }
    }
}
