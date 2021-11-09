using System;

namespace _02.VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] vechicleData = ReadData();                
            IVechicle car = CreateVechicle(vechicleData);

            vechicleData = ReadData();
            IVechicle truck = CreateVechicle(vechicleData);

            vechicleData = ReadData();
            Bus bus = (Bus)CreateVechicle(vechicleData);

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] commandArgs = ReadData();
                string command = commandArgs[0];

                switch (command)
                {
                    case "Drive":
                        DriveVechicle(car, truck, bus, commandArgs[1..]);
                        break;

                    case "DriveEmpty":
                        double distance = double.Parse(commandArgs[2]);                        
                        Console.WriteLine(bus.DriveEmpty(distance));
                        break;

                    case "Refuel":
                        try
                        {
                            RefuelVechicle(car, truck, bus, commandArgs[1..]);
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);                           
                        }
                        break;                        
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void RefuelVechicle(IVechicle car, IVechicle truck, IVechicle bus, string[] commandArgs)
        {
            string vechicleType = commandArgs[0];
            double amount = double.Parse(commandArgs[1]);

            switch (vechicleType)
            {
                case "Car":
                    car.Refuel(amount);
                    break;
                case "Truck":
                    truck.Refuel(amount);
                    break;
                case "Bus":
                    bus.Refuel(amount);
                    break;               
            }
        }

        private static void DriveVechicle(IVechicle car, IVechicle truck, IVechicle bus, string[] commandArgs)
        {
            string vechicleType = commandArgs[0];
            double distance = double.Parse(commandArgs[1]);

            Console.WriteLine(vechicleType switch
                              {
                                  "Car" => car.Drive(distance),
                                  "Truck" => truck.Drive(distance),
                                  _ => bus.Drive(distance),
                              });           
        }       

        private static IVechicle CreateVechicle(string[] vechicleData)
        {
            string type = vechicleData[0];
            double fuel = double.Parse(vechicleData[1]);
            double litters = double.Parse(vechicleData[2]);
            double tankCpacity = double.Parse(vechicleData[3]);

            return type switch
            {
                "Car" => new Car(fuel, litters, tankCpacity),
                "Truck" => new Truck(fuel, litters, tankCpacity),
                _ => new Bus(fuel, litters, tankCpacity),
            };
        }

        private static string[] ReadData()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
