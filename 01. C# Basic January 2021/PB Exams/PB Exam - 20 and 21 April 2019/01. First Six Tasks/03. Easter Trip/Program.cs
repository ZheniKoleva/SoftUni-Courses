using System;

namespace _03.EasterTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string holidayPeriod = Console.ReadLine();
            int nightsNumber = int.Parse(Console.ReadLine());

            double pricePerNight = 0.00;

            switch (destination)
            {
                case "France":

                    switch (holidayPeriod)
                    {
                        case "21-23":
                            pricePerNight = 30.00;
                            break;
                        case "24-27":
                            pricePerNight = 35.00;
                            break;
                        case "28-31":
                            pricePerNight = 40.00;
                            break;
                    }

                    break;

                case "Italy":

                    switch (holidayPeriod)
                    {
                        case "21-23":
                            pricePerNight = 28.00;
                            break;
                        case "24-27":
                            pricePerNight = 32.00;
                            break;
                        case "28-31":
                            pricePerNight = 39.00;
                            break;
                    }

                    break;

                case "Germany":

                    switch (holidayPeriod)
                    {
                        case "21-23":
                            pricePerNight = 32.00;
                            break;
                        case "24-27":
                            pricePerNight = 37.00;
                            break;
                        case "28-31":
                            pricePerNight = 43.00;
                            break;
                    }

                    break;

            }

            double totalPrice = nightsNumber * pricePerNight;
            Console.WriteLine($"Easter trip to {destination} : {totalPrice:f2} leva.");
        }
    }
}
