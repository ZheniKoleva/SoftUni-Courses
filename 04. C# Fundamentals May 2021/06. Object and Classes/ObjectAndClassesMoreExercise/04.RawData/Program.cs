using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());

            List<Car> carsList = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                Car current = ReadCar();
                carsList.Add(current);
            }

            string typeToPrint = Console.ReadLine();

            PrintCars(carsList, typeToPrint);

            //List<Car> filtered = FilterCarsToPrint(carsList, typeToPrint);

            //Console.WriteLine(string.Join(Environment.NewLine, filtered));
        }

        private static void PrintCars(List<Car> carsList, string typeToPrint)
        {
            foreach (var car in carsList)
            {
                if (car.CargoData.CargoType == typeToPrint && car.CargoData.Weight < 1000)
                {
                    Console.WriteLine(car);
                }
                else if (car.CargoData.CargoType == typeToPrint && car.EngineData.Power > 250)
                {
                    Console.WriteLine(car);
                }
            }
        }

        //private static List<Car> FilterCarsToPrint(List<Car> carsList, string typeToPrint)
        //{
        //    List<Car> filtered = new List<Car>();

        //    if (typeToPrint == "fragile")
        //    {
        //        filtered = carsList
        //            .Where(c => c.CargoData.CargoType == typeToPrint && c.CargoData.Weight < 1000)
        //            .ToList();
        //    }
        //    else
        //    {
        //        filtered = carsList
        //            .Where(c => c.CargoData.CargoType == typeToPrint && c.EngineData.Power > 250)
        //            .ToList();
        //    }

        //    return filtered;
        //}

        private static Car ReadCar()
        {
            string[] carData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = carData[0];
            int engineSpeed = int.Parse(carData[1]);
            int enginePower = int.Parse(carData[2]);
            int cargoWeight = int.Parse(carData[3]);
            string cargoType = carData[4];

            return new Car(model, engineSpeed, enginePower, cargoWeight, cargoType);
        }
    }

    public class Cargo
    {
        private int weight;

        private string cargoType;

        public Cargo(int weight, string cargoType)
        {
            Weight = weight;
            CargoType = cargoType;
        }
        public int Weight { get; set; }

        public string CargoType { get; set; }

    }

    public class Engine
    {
        private int speed;

        private int power;

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
        public int Speed { get; set; }

        public int Power { get; set; }
    }

    public class Car
    {
        private string model;

        private Engine engineData;

        private Cargo cargoData;

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType)
        {
            Model = model;
            EngineData = new Engine(engineSpeed, enginePower);
            CargoData = new Cargo(cargoWeight, cargoType);
        }

        public string Model { get; set; }

        public Engine EngineData { get; set; }

        public Cargo CargoData { get; set; }

        public override string ToString()
        {
            return Model;
        }
    }
}
