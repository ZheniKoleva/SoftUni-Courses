namespace _01.Vehicles
{
    public class Truck : Vechicle
    {
        private const double FuelIncreaseConsuption = 1.6;

        private const double PercentRefueled = 0.95;

        public Truck(double fuelQuantity, double fuelConsuptionPerKm)
           : base(fuelQuantity, fuelConsuptionPerKm)
        {            
        }

        public override double FuelConsuptionPerKm 
            => base.FuelConsuptionPerKm + FuelIncreaseConsuption;

        public override void Refuel(double fuelAmount)
            => base.Refuel(fuelAmount * PercentRefueled);       
    }
}
