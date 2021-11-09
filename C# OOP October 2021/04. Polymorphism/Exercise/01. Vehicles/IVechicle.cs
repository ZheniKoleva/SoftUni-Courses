namespace _01.Vehicles
{
    public interface IVechicle
    {
        public double FuelQuantity { get; }

        public double FuelConsuptionPerKm { get; }

        public string Drive(double distance);

        public void Refuel(double fuelAmount);

    }
}
