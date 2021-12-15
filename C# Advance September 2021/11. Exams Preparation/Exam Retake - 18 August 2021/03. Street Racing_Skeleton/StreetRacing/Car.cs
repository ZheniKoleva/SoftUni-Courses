using System.Text;

namespace StreetRacing
{
    public class Car
    {
        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            Make = make;
            Model = model;
            LicensePlate = licensePlate;
            HorsePower = horsePower;
            Weight = weight;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public string  LicensePlate { get; set; }

        public int HorsePower { get; set; }

        public double Weight { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Make: {Make}");
            output.AppendLine($"Model: {Model}");
            output.AppendLine($"License Plate: {LicensePlate}");
            output.AppendLine($"Horse Power: {HorsePower}");
            output.Append($"Weight: {Weight}");

            return output.ToString();
        }

    }
}
