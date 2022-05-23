using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicleCatalog = new List<Vehicle>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                Vehicle current = CreateVechicle(line);
                vehicleCatalog.Add(current);

                line = Console.ReadLine();
            }

            string modelToPrint = Console.ReadLine();

            while (modelToPrint != "Close the Catalogue")
            {
                PrintDesiredModel(vehicleCatalog, modelToPrint);

                modelToPrint = Console.ReadLine();
            }

            double carsAverage = GetAverageHorsePower(vehicleCatalog, "Car");
            double trucksAverage = GetAverageHorsePower(vehicleCatalog, "Truck");
           
            Console.WriteLine($"Cars have average horsepower of: {carsAverage:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAverage:f2}."); 
        }

        private static double GetAverageHorsePower(List<Vehicle> vehicleCatalog, string typeOfVehicle)
        {
            double averageValue = 0.0;

            if (vehicleCatalog.Any(v => v.Type == typeOfVehicle))
            {
                averageValue = vehicleCatalog
                    .Where(v => v.Type == typeOfVehicle)
                    .Average(v => v.HorsePower);
            }

            return averageValue;
        }

        private static void PrintDesiredModel(List<Vehicle> vehicleCatalog, string modelToPrint)
        {
            Vehicle dataToPrint = vehicleCatalog.FirstOrDefault(v => v.Model == modelToPrint);
            Console.WriteLine(dataToPrint);
        }

        private static Vehicle CreateVechicle(string line)
        {
            string[] vehicleData = line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string typeOfVechicle = vehicleData[0] == "car" ? "Car" : "Truck";
            string model = vehicleData[1];
            string color = vehicleData[2];
            double horsePower = double.Parse(vehicleData[3]);

            return new Vehicle(typeOfVechicle, model, color, horsePower);
        }

        public class Vehicle
        {
            private string typeOfVehicle;

            private string model;

            private string color;

            private double horsePower;

            public Vehicle(string typeofVehicle, string model, string color, double horsePower)
            {
                Type = typeofVehicle;
                Model = model;
                Color = color;
                HorsePower = horsePower;
            }

            public string Type { get; set; }

            public string Model { get; set; }

            public string Color { get; set; }

            public double HorsePower { get; set; }

            public override string ToString()
            {
                StringBuilder vehicle = new StringBuilder();
                vehicle.AppendLine($"Type: {Type}");
                vehicle.AppendLine($"Model: {Model}");
                vehicle.AppendLine($"Color: {Color}");
                vehicle.Append($"Horsepower: {HorsePower}");

                return vehicle.ToString();
            }

        }

    }
}
