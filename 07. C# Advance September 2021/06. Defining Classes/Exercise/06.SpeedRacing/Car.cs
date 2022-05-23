namespace _06.SpeedRacing
{
    using System;

    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public void Drive(int distance)
        {
            double fuelNeeded = distance * FuelConsumptionPerKilometer;

            bool canDrive = fuelNeeded <= FuelAmount;

            if (canDrive)
            {
                FuelAmount -= fuelNeeded;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString() => $"{Model} {FuelAmount:f2} {TravelledDistance}";
       
    }
}
