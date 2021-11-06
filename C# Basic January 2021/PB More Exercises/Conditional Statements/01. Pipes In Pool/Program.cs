using System;

namespace _01._PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            double poolVolume = double.Parse(Console.ReadLine());
            double debitP1 = double.Parse(Console.ReadLine());
            double debitP2 = double.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double litersP1 = debitP1 * hours;
            double litersP2 = debitP2 * hours;
            double volume2 = litersP1 + litersP2;
            double percentvolume2 = (volume2 * 100) / poolVolume;
            double percentP1 = (litersP1 * 100) / volume2;
            double percentP2 = (litersP2 * 100) / volume2;

            if (volume2 <= poolVolume)
            {
                Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.",
                    percentvolume2, percentP1, percentP2);
            }
            else
            {
                Console.WriteLine("For {0} hours the pool overflows with {1} liters.",
                    hours, (volume2 - poolVolume));
            }

        }
    }
}
