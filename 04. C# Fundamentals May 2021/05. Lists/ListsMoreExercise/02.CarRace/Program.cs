using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = ReadInput();

            int limit = numbers.Count / 2;

            double carLeft = 0;
            double carRight = 0;

            for (int i = 0; i < limit; i++)
            {
                if (numbers[i] == 0)
                {
                    carLeft *= 0.80;
                }
                else
                {
                    carLeft += numbers[i];
                }

                if (numbers[numbers.Count - 1 - i] == 0)
                {
                    carRight *= 0.80;
                }
                else
                {
                    carRight += numbers[numbers.Count - 1 - i];
                }

            }

            //double carLeft = GetCarTimeLeft(numbers, 0, limit);
            //double carRight = GetCarTimeRight(numbers, numbers.Count - 1, limit + 1);

            Console.WriteLine(GetTheWinner(carLeft, carRight)); 

        }

      

        //private static double GetCarTimeLeft(List<double> numbers, int startIndx, int endIndx)
        //{
        //    double carTime = 0;
            
        //    for (int i = startIndx; i < endIndx; i++)
        //    {
        //        if (numbers[i] == 0)
        //        {
        //            carTime *= 0.80;
        //            continue;
        //        }               
                
        //        carTime += numbers[i];
        //    }

        //    return carTime;
        //}

       
        private static string GetTheWinner(double carLeft, double carRight)
        {    
            if (carLeft < carRight)
            {
                return $"The winner is left with total time: {carLeft}";
            }
            else if (carLeft > carRight)
            {
                return $"The winner is right with total time: {carRight}";
            }

            return null;
           
        }

        private static List<double> ReadInput()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();
        }
    }
}
