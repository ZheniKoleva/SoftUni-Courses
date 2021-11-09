namespace _02.VehiclesExtension
{
    public class Car : Vechicle
    {
        private const double FuelIncreaseConsuption = 0.9;

        public Car(double fuelQuantity, double fuelConsuptionPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsuptionPerKm, tankCapacity)
        {            
        }

        public override double FuelConsuptionPerKm 
            => base.FuelConsuptionPerKm + FuelIncreaseConsuption;
    }
}
