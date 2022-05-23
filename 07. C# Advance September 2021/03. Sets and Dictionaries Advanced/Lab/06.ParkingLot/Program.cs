using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carsLot = new HashSet<string>();
           
            string line;

            while ((line = Console.ReadLine()) != "END")
            {
                FillCarsLot(carsLot, line);
            }

            Console.WriteLine(carsLot.Any() 
                ? string.Join(Environment.NewLine, carsLot)
                : "Parking Lot is Empty");
        }

        private static void FillCarsLot(HashSet<string> carsLot, string line)
        {
            string[] data = line
                       .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string direction = data[0];
            string carsNUmber = data[1];

            _= direction.Equals("IN") 
                ? carsLot.Add(carsNUmber) 
                : carsLot.Remove(carsNUmber);
        }
       
    }
}
