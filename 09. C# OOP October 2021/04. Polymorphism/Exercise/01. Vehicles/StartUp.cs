using System;

namespace _01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] vechicleData = ReadData();                
            IVechicle car = CreateVechicle(vechicleData);

            vechicleData = ReadData();
            IVechicle truck = CreateVechicle(vechicleData);

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] commandArgs = ReadData();                

                ExecuteCommands(car, truck, commandArgs);
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ExecuteCommands(IVechicle car, IVechicle truck, string[] commandArgs)
        {
            string command = commandArgs[0];
            string vechicleType = commandArgs[1];
            double distanceOrfuelAmount = double.Parse(commandArgs[2]);

            switch (command)
            {
                case "Drive" when vechicleType == "Car":                    
                    Console.WriteLine(car.Drive(distanceOrfuelAmount));
                    break;
                case "Drive" when vechicleType == "Truck":                    
                    Console.WriteLine(truck.Drive(distanceOrfuelAmount));
                    break;
                case "Refuel" when vechicleType == "Car":                   
                    car.Refuel(distanceOrfuelAmount);
                    break;
                case "Refuel" when vechicleType == "Truck":                    
                    truck.Refuel(distanceOrfuelAmount);
                    break;
            }
        }

        private static IVechicle CreateVechicle(string[] vechicleData)
        {
            string type = vechicleData[0];
            double fuel = double.Parse(vechicleData[1]);
            double litters = double.Parse(vechicleData[2]);

            return type switch
            {
                "Car" => new Car(fuel, litters),
                _ => new Truck(fuel, litters)
            };
        }

        private static string[] ReadData()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }       
    }
}
