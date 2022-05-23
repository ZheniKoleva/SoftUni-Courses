using System;

namespace _07._SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine().ToLower();
            string groupType = Console.ReadLine().ToLower();
            int studentsNumber = int.Parse(Console.ReadLine());
            int numberOfNights = int.Parse(Console.ReadLine());

            double hotelRate = 0.00;
            double totalPrice = 0.00;
            string sport = "";

            switch (groupType)
            {
                case "boys":                
                    if (season == "winter")
                    {
                        hotelRate = 9.60;
                        sport = "Judo";
                    }
                    else if (season == "spring")
                    {
                        hotelRate = 7.20;
                        sport = "Tennis";
                    }
                    else if (season == "summer")
                    {
                        hotelRate = 15.00;
                        sport = "Football";
                    }
                    break;
                case "girls":
                    if (season == "winter")
                    {
                        hotelRate = 9.60;
                        sport = "Gymnastics";
                    }
                    else if (season == "spring")
                    {
                        hotelRate = 7.20;
                        sport = "Athletics";
                    }
                    else if (season == "summer")
                    {
                        hotelRate = 15.00;
                        sport = "Volleyball";
                    }
                    break;
                    case "mixed":
                    if (season == "winter")
                    {
                        hotelRate = 10.00;
                        sport = "Ski";
                    }
                    else if (season == "spring")
                    {
                        hotelRate = 9.50;
                        sport = "Cycling";
                    }
                    else if (season == "summer")
                    {
                        hotelRate = 20.00;
                        sport = "Swimming";
                    }
                    break;             
            }

            totalPrice = hotelRate * numberOfNights * studentsNumber;

            if (studentsNumber >= 50)
            {
                totalPrice -= totalPrice * 0.50;
            }
            else if (studentsNumber >= 20 && studentsNumber < 50)
            {
                totalPrice -= totalPrice * 0.15;
            }
            else if (studentsNumber >= 10 && studentsNumber < 20)
            {
                totalPrice -= totalPrice * 0.05;
            }
            Console.WriteLine($"{sport} {totalPrice:f2} lv.");            
        }
    }
}
