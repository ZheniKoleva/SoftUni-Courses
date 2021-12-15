namespace CarManufacturer
{
    using System;
    using System.Text;

    public class Car
    {
        private string make;

        private string model;

        private int year;

        private double fuelQuantity;

        private double fuelConsumption;

        private Engine engine;

        private Tire[] tires;

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {           
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, 
            Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {            
            Engine = engine;
            Tires = tires;
        }

        public string Make 
        {
            get => make;
            set => make = value;
        }       

        public string Model 
        {
            get => model;
            set => model = value;
        }        

        public int Year 
        {
            get => year;
            set => year = value;
        }

        public double FuelQuantity 
        {
            get => fuelQuantity;
            set => fuelQuantity = value;
        }

        public double FuelConsumption 
        {
            get => fuelConsumption;
            set => fuelConsumption = value;
        }

        public Engine Engine 
        { 
            get => engine; 
            set => engine = value; 
        }

        public Tire[] Tires 
        { 
            get => tires; 
            set => tires = value; 
        }

        public void Drive(double distance)
        {
            double fuelNeeded = distance * (fuelConsumption / 100);
            bool canDrive = fuelNeeded <= fuelQuantity;

            if (canDrive)
            {
                fuelQuantity -= fuelNeeded;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Make: {Make}");
            output.AppendLine($"Model: {Model}");
            output.AppendLine($"Year: {Year}");
            output.AppendLine($"HorsePowers: {Engine.HorsePower}");
            output.Append($"FuelQuantity: {FuelQuantity}");

            return output.ToString();
        }
    }
}
