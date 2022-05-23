using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carData = ExtractData();
                Car car = CreateCar(carData);

                cars.Add(car);
            }

            string searchedType = Console.ReadLine();

            Predicate<Car> filter = GetFilter(searchedType);

            var filtered = cars.Where(x => filter(x));

            Console.WriteLine(string.Join(Environment.NewLine, filtered));
        }

        private static Predicate<Car> GetFilter(string searchedType)
        {
            return searchedType switch
            {
                "fragile" => x => x.Cargo.Type.Equals("fragile") && x.Tires.Any(t => t.Pressure < 1),
                "flammable" => x => x.Cargo.Type.Equals("flammable") && x.Engine.Power > 250,
                _ => null,
            };
        }

        private static Car CreateCar(string[] carData)
        {
            string model = carData[0];
            int engineSpeed = int.Parse(carData[1]);
            int enginePower = int.Parse(carData[2]);
            int cargoWeight = int.Parse(carData[3]);
            string cargoType = carData[4];
            string[] tiresArgs = carData[5..];

            return new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tiresArgs);
        }

        private static string[] ExtractData()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
