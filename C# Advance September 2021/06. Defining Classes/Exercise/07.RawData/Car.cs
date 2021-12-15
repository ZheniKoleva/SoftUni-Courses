namespace _07.RawData
{
    public class Car
    {
        public Car(string model, int engineSpeed, int enginePower, 
            int cargoWeight, string cargoType, string[] tiresArgs)
        {
            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoType, cargoWeight);
            Tires = new Tire[4];

            int tireIndx = 0;

            for (int i = 0; i < tiresArgs.Length; i += 2)
            {
                double tirePressure = double.Parse(tiresArgs[i]);
                int tireAge = int.Parse(tiresArgs[i + 1]);

                Tires[tireIndx] = new Tire(tireAge, tirePressure);
                tireIndx++;
            }
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tires { get; set; }

        public override string ToString() => Model;        
    }
}
