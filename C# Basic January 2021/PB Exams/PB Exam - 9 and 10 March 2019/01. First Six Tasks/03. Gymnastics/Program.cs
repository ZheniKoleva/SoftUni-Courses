using System;

namespace _03.Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string equipment = Console.ReadLine();

            double dificulty = 0.00;
            double performance = 0.00;
            double totalPoints = 0.00;

            switch (equipment)
            {
                case "ribbon":
                    switch (country)
                    {
                        case "Russia":
                            dificulty = 9.100;
                            performance = 9.400;
                            break;
                        case "Bulgaria":
                            dificulty = 9.600;
                            performance = 9.400;
                            break;
                        case "Italy":
                            dificulty = 9.200;
                            performance = 9.500;
                            break;
                    }

                    break;

                case "hoop":
                    switch (country)
                    {
                        case "Russia":
                            dificulty = 9.300;
                            performance = 9.800;
                            break;
                        case "Bulgaria":
                            dificulty = 9.550;
                            performance = 9.750;
                            break;
                        case "Italy":
                            dificulty = 9.450;
                            performance = 9.350;
                            break;
                    }

                    break;

                case "rope":
                    switch (country)
                    {
                        case "Russia":
                            dificulty = 9.600;
                            performance = 9.000;
                            break;
                        case "Bulgaria":
                            dificulty = 9.500;
                            performance = 9.400;
                            break;
                        case "Italy":
                            dificulty = 9.700;
                            performance = 9.150;
                            break;
                    }

                    break;
            }

            totalPoints = dificulty + performance;
            double percentPoints = (20.000 - totalPoints) / 20 * 100;

            Console.WriteLine($"The team of {country} get {totalPoints:f3} on {equipment}.");
            Console.WriteLine($"{percentPoints:f2}%");
        }
    }
}
