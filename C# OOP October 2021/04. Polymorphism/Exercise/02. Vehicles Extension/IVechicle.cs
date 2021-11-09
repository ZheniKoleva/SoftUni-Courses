namespace _02.VehiclesExtension
{
   public interface IVechicle
    {
        public double FuelQuantity { get; }

        public double FuelConsuptionPerKm { get; }

        public double TankCapacity { get; }  

        public string Drive(double distance);

        public void Refuel(double fuelAmount);

    }
}
