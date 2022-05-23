namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double Default_CubicCentimeters = 3000;

        private const int Default_HorsePower_Min = 250;

        private const int Default_HorsePower_Max = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, Default_CubicCentimeters, Default_HorsePower_Min, Default_HorsePower_Max)
        {
        }
    }
}
