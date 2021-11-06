namespace Cars
{
    class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int batery)
        {
            this.Model = model;
            this.Color = color;
            this.Batery = batery;
        }

        public int Batery { get ; set ; }

        public string Model { get ; set ; }

        public string Color { get ; set ; }

        public string Start()
            => "Engine Start";

        public string Stop()
            => "Breaaak!";

        public override string ToString()
            => $"{this.Color} {this.GetType().Name} {this.Model} with {this.Batery} Batteries\r\n" +
            $"{this.Start()}\r\n{this.Stop()}";       
    }
}
