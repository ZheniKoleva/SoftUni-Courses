using System;

namespace _07.HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine().ToLower();
            int nightsNumber = int.Parse(Console.ReadLine());

            double studioPrice = 0.00;
            double apartmentPrice = 0.00;
            double studioTotalPrice = 0.00;
            double apartmentTotalPrice = 0.00;

            switch (month)
            {
                case "may":
                case "october":
                    studioPrice = 50.00;
                    apartmentPrice = 65.00;
                    break;
                case "june":
                case "september":
                    studioPrice = 75.20;
                    apartmentPrice = 68.70;
                    break;
                case "july":
                case "august":
                    studioPrice = 76.00;
                    apartmentPrice = 77.00;
                    break;
            }

            studioTotalPrice = studioPrice * nightsNumber;
            apartmentTotalPrice = apartmentPrice * nightsNumber;

            if ((nightsNumber > 7 && nightsNumber <= 14) && (month == "may" || month == "october"))
            {
                studioTotalPrice -= studioTotalPrice * 0.05;
            }
            else if (nightsNumber > 14)
            {
                apartmentTotalPrice -= apartmentTotalPrice * 0.10;
                switch (month)
                {
                    case "may":
                    case "october":
                        studioTotalPrice -= studioTotalPrice * 0.30;
                        break;
                    case "june":
                    case "september":
                        studioTotalPrice -= studioTotalPrice * 0.20;
                        break;
                }
            }

            Console.WriteLine($"Apartment: {apartmentTotalPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioTotalPrice:f2} lv.");
        }
    }
}
