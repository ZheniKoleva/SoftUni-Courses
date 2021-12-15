using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int enginesCount = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < enginesCount; i++)
            {
                string[] engineData = ExtractData();

                Engine engine = CreateEngine(engineData);

                engines.Add(engine);
            }

            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carData = ExtractData();

                Car car = CreateCar(engines, carData);

                cars.Add(car);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

        private static Car CreateCar(List<Engine> engines, string[] carData)
        {
            string model = carData[0];
            string engineModel = carData[1];
            Engine engine = engines.First(x => x.Model.Equals(engineModel));

            if (carData.Length == 3)
            {
                bool isWeight = int.TryParse(carData[2], out int weight);

                if (!isWeight)
                {
                    string color = carData[2];

                    return new Car(model, engine, color);
                }

                return new Car(model, engine, weight);
            }
            else if (carData.Length == 4)
            {
                int weight = int.Parse(carData[2]);
                string color = carData[3];

                return new Car(model, engine, weight, color);
            }

            return new Car(model, engine);

        }

        private static Engine CreateEngine(string[] engineData)
        {
            string model = engineData[0];
            int power = int.Parse(engineData[1]);

            if (engineData.Length == 3)
            {
                bool isDisplacement = int.TryParse(engineData[2], out int displacement);

                if (!isDisplacement)
                {
                    string efficiency = engineData[2];

                    return new Engine(model, power, efficiency);
                }

                return new Engine(model, power, displacement);
            }
            else if (engineData.Length == 4)
            {
                int displacement = int.Parse(engineData[2]);
                string efficiency = engineData[3];

                return new Engine(model, power, displacement, efficiency);
            }

            return new Engine(model, power);

        }

        private static string[] ExtractData()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
