namespace SoftUniParking
{
    using System.Text;

    public class Car
    { 
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Make: {Make}");
            output.AppendLine($"Model: {Model}");
            output.AppendLine($"HorsePower: {HorsePower}");
            output.Append($"RegistrationNumber: {RegistrationNumber}");

            return output.ToString();
        }
    }
}