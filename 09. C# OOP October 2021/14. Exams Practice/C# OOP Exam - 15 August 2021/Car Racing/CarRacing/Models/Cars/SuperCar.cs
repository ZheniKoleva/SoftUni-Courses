namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double Default_FuelAvailable = 80;

        private const double Default_FuelConsumptionPerRace = 10;


        public SuperCar(
            string make, 
            string model, 
            string vIN, 
            int horsePower) 
            : base(make, model, vIN, horsePower, Default_FuelAvailable, Default_FuelConsumptionPerRace)
        {
        }
    }
}
