namespace _08.CarSalesman2
{
    using System.Text;

    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
            Displacement = default;
            Efficiency = default;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
           : this(model, power)
        {
            Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
           : this(model, power)
        {
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"  {Model}:");
            output.AppendLine($"    Power: {Power}");
            string displacementResult = Displacement == default ? "n/a" : $"{Displacement}";
            output.AppendLine($"    Displacement: {displacementResult}");
            string efficiencyResult = Efficiency == default ? "n/a" : $"{Efficiency}";
            output.Append($"    Efficiency: {efficiencyResult}");

            return output.ToString();
        }
    }
}