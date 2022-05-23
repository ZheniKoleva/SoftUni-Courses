using System;
using System.Collections.Generic;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());

            Dictionary<string, Car> cars = FillCars(carsCount);

            string line;

            while ((line = Console.ReadLine()) != "End")
            {
                string[] carData = ExtractData(line);
                DriveCars(cars, carData);               
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars.Values));
        }

        private static void DriveCars(Dictionary<string, Car> cars, string[] carData)
        {
            string model = carData[1];
            int distance = int.Parse(carData[2]);

            if (cars.ContainsKey(model))
            {
                cars[model].Drive(distance);
            }
        }

        private static Dictionary<string, Car> FillCars(int carsCount)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carData = ExtractData();

                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsupmtion = double.Parse(carData[2]);

                if (!cars.ContainsKey(model))
                {
                    cars.Add(model, new Car(model, fuelAmount, fuelConsupmtion));
                }
            }

            return cars;
        }

        private static string[] ExtractData()
            => Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        private static string[] ExtractData(string line)
            => line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }
}
