namespace _08.CarSalesman
{
    using System.Text;

    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = default;
            Color = default;
        }

        public Car(string model, Engine engine, string color)
            :this(model, engine)
        {            
            Color = color;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, int weight, string color)
            :this(model, engine)
        {           
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"{Model}:");
            output.AppendLine($"{Engine}");
            string weightResult = Weight == default ? "n/a" : $"{Weight}";
            output.AppendLine($"  Weight: {weightResult}");
            string colorResult = Color == default ? "n/a" : $"{Color}";
            output.Append($"  Color: {colorResult}");

            return output.ToString();
        }
    }
}
