using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());

            List<Car> carList = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                Car current = ReadCar();
                carList.Add(current);
            }

            string line = Console.ReadLine();

            while (line != "End")
            {
                DriveCar(carList, line);
                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, carList));
        }

        private static void DriveCar(List<Car> carList, string line)
        {
            string[] data = line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = data[1];
            double distanceToTravel = double.Parse(data[2]);

            Car carToMove = carList.First(c => c.Model == model);
            carToMove.CanMove(distanceToTravel);
        }

        private static Car ReadCar()
        {
            string[] carData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = carData[0];
            double fuelAmount = double.Parse(carData[1]);
            double fuelConsumption = double.Parse(carData[2]);

            return new Car(model, fuelAmount, fuelConsumption);
        }
    }

    public class Car
    {
        private string model;

        private double fuelAmount;

        private double fuelConsumotion;

        private double distance;

        public Car(string modelName, double fuelAmount, double fuelConsumption)
        {
            Model = modelName;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public double Distance { get; set; } = 0;

        public void CanMove(double distance)
        {
            double fuelNeeded = FuelConsumption * distance;

            if (FuelAmount >= fuelNeeded)
            {
                FuelAmount -= fuelNeeded;
                Distance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {Distance}";
        }

    }
}
