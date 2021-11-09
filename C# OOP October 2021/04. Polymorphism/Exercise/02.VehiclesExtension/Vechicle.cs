using System;

namespace _02.VehiclesExtension
{
    public abstract class Vechicle : IVechicle
    {    
        private double fuelQuantity;
        protected Vechicle(double fuelQuantity, double fuelConsuptionPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsuptionPerKm = fuelConsuptionPerKm;
        }

        public double TankCapacity { get; private set; }

        public double FuelQuantity 
        {
            get => this.fuelQuantity;
            private set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                    return;
                }

                this.fuelQuantity = value;   
            } 
        }

        public virtual double FuelConsuptionPerKm { get; private set; }       

        public virtual string Drive(double distance)
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
        {
            if (fuelAmount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");                
            }

            if (fuelAmount > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");                
            }
            
            this.FuelQuantity += fuelAmount;        
        }        

        public override string ToString()
            => $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
