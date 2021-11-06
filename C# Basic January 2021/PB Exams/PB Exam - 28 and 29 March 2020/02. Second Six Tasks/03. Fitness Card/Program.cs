using System;

namespace _03.FitnessCard
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine().ToLower());
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double monthTax = 0;

            switch (sport)
            {
                case "Gym":
                    switch (gender)
                    {
                        case 'm':
                            monthTax = 42.00;
                            break;

                        case 'f':
                            monthTax = 35.00;
                            break;
                    }
                    break;

                case "Boxing":
                    switch (gender)
                    {
                        case 'm':
                            monthTax = 41.00;
                            break;

                        case 'f':
                            monthTax = 37.00;
                            break;
                    }
                    break;

                case "Yoga":
                    switch (gender)
                    {
                        case 'm':
                            monthTax = 45.00;
                            break;

                        case 'f':
                            monthTax = 42.00;
                            break;
                    }
                    break;

                case "Zumba":
                    switch (gender)
                    {
                        case 'm':
                            monthTax = 34.00;
                            break;

                        case 'f':
                            monthTax = 31.00;
                            break;
                    }
                    break;

                case "Dances":
                    switch (gender)
                    {
                        case 'm':
                            monthTax = 51.00;
                            break;

                        case 'f':
                            monthTax = 53.00;
                            break;
                    }
                    break;

                case "Pilates":
                    switch (gender)
                    {
                        case 'm':
                            monthTax = 39.00;
                            break;

                        case 'f':
                            monthTax = 37.00;
                            break;
                    }
                    break;
               
            }

            if (age <= 19)
            {
                monthTax -= monthTax * 0.20;
            }

            if (budget >= monthTax)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                double moneyNeeded = monthTax - budget;
                Console.WriteLine($"You don't have enough money! You need ${moneyNeeded:f2} more.");
            }

        }
    }
}
