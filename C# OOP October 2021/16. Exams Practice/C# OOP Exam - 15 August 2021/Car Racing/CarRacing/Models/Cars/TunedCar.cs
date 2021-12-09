using System;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double Default_FuelAvailable = 65;

        private const double Default_FuelConsumptionPerRace = 7.5;

        private const double HorsePower_Reduction = 0.97;

        public TunedCar(
            string make,
            string model,
            string vIN,
            int horsePower)
            : base(make, model, vIN, horsePower, Default_FuelAvailable, Default_FuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
            HorsePower = (int)(Math.Round(HorsePower * HorsePower_Reduction));
        }

    }
}
