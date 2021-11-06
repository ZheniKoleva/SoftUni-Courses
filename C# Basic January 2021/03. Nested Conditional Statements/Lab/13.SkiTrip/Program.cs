using System;

namespace _13.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string evaluation = Console.ReadLine();

            double pricePerNight = 0.00;
            double totalPrice = 0.00;
            double discount = 0.00;

            switch (typeOfRoom)
            {
                case "room for one person":
                    pricePerNight = 18.00;
                    break;

                case "apartment":
                    pricePerNight = 25.00;
                    if (days < 10)
                    {
                        discount = 0.30;
                    }
                    else if (days <= 15)
                    {
                        discount = 0.35;
                    }
                    else if (days > 15)
                    {
                        discount = 0.50;
                    }
                    break;

                case "president apartment":
                    pricePerNight = 35.00;
                    if (days < 10)
                    {
                        discount = 0.10;
                    }
                    else if (days <= 15)
                    {
                        discount = 0.15;
                    }
                    else if (days > 15)
                    {
                        discount = 0.20;
                    }
                    break;
            }

            totalPrice = pricePerNight * (days - 1);
            totalPrice -= totalPrice * discount;

            if (evaluation.Equals("positive"))
            {
                totalPrice += totalPrice * 0.25;
            }
            else
            {
                totalPrice -= totalPrice * 0.10;
            }

            Console.WriteLine($"{totalPrice:f2}");           
            
        }

    }
}
