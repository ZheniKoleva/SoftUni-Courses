namespace _01.Vehicles
{
    public abstract class Vechicle : IVechicle
    {    
        protected Vechicle(double fuelQuantity, double fuelConsuptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsuptionPerKm = fuelConsuptionPerKm;
        }

        public double FuelQuantity { get; private set; }

        public virtual double FuelConsuptionPerKm { get; }

        public string Drive(double distance)
        {
            double fuelNeeded = this.FuelConsuptionPerKm * distance;
            bool canDrive = this.FuelQuantity >=  fuelNeeded;

            if (!canDrive)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuelAmount)
            => this.FuelQuantity += fuelAmount;

        public override string ToString()
            => $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
