using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            
            string line;

            while ((line = Console.ReadLine()) != "No more tires")
            {
                string[] tiresArg = ExtractData(line);

                FullfillTires(tires, tiresArg);                
            }

            List<Engine> engines = new List<Engine>();

            while ((line = Console.ReadLine()) != "Engines done")
            {
                string[] engineArg = ExtractData(line);

                FullfillEngines(engines, engineArg);
            }

            List<Car> cars = new List<Car>();

            while ((line = Console.ReadLine()) != "Show special")
            {  
                string[] carArg = ExtractData(line);

                FullfillCars(cars, engines, tires, carArg);
            }

            Predicate<Car> carFilter = car => car.Year >= 2017 && car.Engine.HorsePower > 330
                                   && (car.Tires.Sum(x => x.Pressure) > 9 && car.Tires.Sum(x => x.Pressure) < 10);


            var filteredCar = cars.Where(x => carFilter(x));

            foreach (var car in filteredCar)
            {
                double distance = 20;
                car.Drive(distance);
                Console.WriteLine(car.WhoAmI());
            }
        }

        private static void FullfillCars(List<Car> cars, List<Engine> engines, List<Tire[]> tires, string[] carArg)
        {
            string make = carArg[0];
            string model = carArg[1];
            int year = int.Parse(carArg[2]);
            double fuelQuantity = double.Parse(carArg[3]);
            double fuelConsumption = double.Parse(carArg[4]);
            int engineIndx = int.Parse(carArg[5]);
            int tiresIndx = int.Parse(carArg[6]);

            Car currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption,
                    engines[engineIndx], tires[tiresIndx]);

            cars.Add(currentCar);
        }

        private static void FullfillEngines(List<Engine> engines, string[] engineArg)
        {
            int horsePower = int.Parse(engineArg[0]);
            double cubicCapacity = double.Parse(engineArg[1]);

            engines.Add(new Engine(horsePower, cubicCapacity));
        }

        private static void FullfillTires(List<Tire[]> tires, string[] tiresArg)
        {
            List<Tire> tiresSet = new List<Tire>();

            for (int i = 0; i < tiresArg.Length; i += 2)
            {
                int horsePower = int.Parse(tiresArg[i]);
                double tirePressure = double.Parse(tiresArg[i + 1]);

                tiresSet.Add(new Tire(horsePower, tirePressure));
            }

            tires.Add(tiresSet.ToArray());
        }      

        private static string[] ExtractData(string line)
        {
            return line
                  .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
