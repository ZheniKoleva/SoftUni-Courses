namespace _01.Vehicles
{
    public class Car : Vechicle
    {
        private const double FuelIncreaseConsuption = 0.9;

        public Car(double fuelQuantity, double fuelConsuptionPerKm) 
            : base(fuelQuantity, fuelConsuptionPerKm)
        {            
        }

        public override double FuelConsuptionPerKm 
            => base.FuelConsuptionPerKm + FuelIncreaseConsuption;
    }
}
