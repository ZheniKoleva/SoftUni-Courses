namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double Default_CubicCentimeters = 5000;

        private const int Default_HorsePower_Min = 400;

        private const int Default_HorsePower_Max = 600;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, Default_CubicCentimeters, Default_HorsePower_Min, Default_HorsePower_Max)
        {
        }
    }
}
