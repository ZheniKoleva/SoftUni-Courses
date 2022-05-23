using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalogVehicles = new Catalog();

            string line = Console.ReadLine();

            while (line != "end")
            {
                FillCatalog(catalogVehicles, line); 

                line = Console.ReadLine();
            }

            catalogVehicles.Cars = catalogVehicles.Cars.OrderBy(c => c.Brand).ToList();
            catalogVehicles.Trucks = catalogVehicles.Trucks.OrderBy(t => t.Brand).ToList();

            Print(catalogVehicles.Cars);
            Print(catalogVehicles.Trucks);
        }

        private static void Print(List<Car> list)
        {
            if (list.Count > 0)
            {
                Console.WriteLine("Cars:");
                Console.WriteLine(string.Join(Environment.NewLine, list));
            }
        }

        private static void Print(List<Truck> list)
        {
            if (list.Count > 0)
            {
                Console.WriteLine("Trucks:");
                Console.WriteLine(string.Join(Environment.NewLine, list));
            }
        }

        private static void FillCatalog(Catalog catalog, string line)
        {
            string[] data = line.Split('/', StringSplitOptions.RemoveEmptyEntries);

            string type = data[0];
            string brand = data[1];
            string model = data[2];
            int weightOrPower = int.Parse(data[3]);

            if (type == "Car")
            {
                Car current = new Car(brand, model, weightOrPower);
                catalog.Cars.Add(current);
            }
            else
            {
                Truck current = new Truck(brand, model, weightOrPower);
                catalog.Trucks.Add(current);
            }
        }
    }

    public class Car
    {
        private string brand;

        private string model;

        private int horsePower;

        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {HorsePower}hp";
        }

    }

    public class Truck
    {
        private string brand;

        private string model;

        private int weight;

        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {Weight}kg";
        }

    }

    public class Catalog
    {
        public List<Car> Cars { get; set; }

        public List<Truck> Trucks { get; set; }

        public Catalog()
        {
            this.Cars = new List<Car>();
            this.Trucks = new List<Truck>();
        }
    }
}
