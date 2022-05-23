namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get ; set ; }

        public string Color { get ; set ; }

        public string Start()
             => "Engine Start";

        public string Stop()
            => "Breaaak!";

        public override string ToString()
           => $"{this.Color} {this.GetType().Name} {this.Model}\r\n" +
            $"{this.Start()}\r\n{this.Stop()}";
    }
}
