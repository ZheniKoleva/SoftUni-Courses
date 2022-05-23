using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> carsRegistry = new Dictionary<string, string>();

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] data = ReadData();

                //string result = ParkingValidation(carsRegistry, data);

                string result = string.Empty;

                string command = data[0];
                string userName = data[1];

                switch (command)
                {
                    case "register":
                        string carNumber = data[2];

                        result = RegisterCar(carsRegistry, userName, carNumber);
                        break;

                    case "unregister":
                        result = UnregisterCar(carsRegistry, userName);
                        break;

                }

                Console.WriteLine(result);
            }

            Print(carsRegistry);

        }

        //private static string ParkingValidation(Dictionary<string, string> carsRegistry, string[] data)
        //{
        //    string command = data[0];
        //    string userName = data[1];

        //    switch (command)
        //    {
        //        case "register":
        //            string carNumber = data[2];

        //            return RegisterCar(carsRegistry, userName, carNumber);

        //        case "unregister":
        //            return UnregisterCar(carsRegistry, userName);

        //    }

        //    return null;
        //}

        private static string[] ReadData()
        {
            return Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        private static void Print(Dictionary<string, string> carsRegistry)
        {
            foreach (var car in carsRegistry)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }

        private static string UnregisterCar(Dictionary<string, string> carsRegistry, string userName)
        {
            bool isRemoved = carsRegistry.Remove(userName);

            if (isRemoved)
            {
                return $"{userName} unregistered successfully";
            }

            return $"ERROR: user {userName} not found";

        }

        private static string RegisterCar(Dictionary<string, string> carsRegistry, string userName, string carNumber)
        {
            if (carsRegistry.ContainsKey(userName))
            {
                return $"ERROR: already registered with plate number {carsRegistry[userName]}";
            }

            carsRegistry.Add(userName, carNumber);
            return $"{userName} registered {carNumber} successfully";

        }
    }
}
