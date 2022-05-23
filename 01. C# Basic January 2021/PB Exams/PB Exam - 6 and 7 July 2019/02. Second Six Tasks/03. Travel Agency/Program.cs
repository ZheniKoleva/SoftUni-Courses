using System;

namespace _03.TravelAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            string cityName = Console.ReadLine();
            string packetType = Console.ReadLine();
            string discountVip = Console.ReadLine();
            int holidayDaysCount = int.Parse(Console.ReadLine());

            if (holidayDaysCount < 1)
            {
                Console.WriteLine("Days must be positive number!");
                return;
            }
            else if (holidayDaysCount > 7)
            {
                holidayDaysCount--;
            }

            double pricePerNight = 0.00;            

            switch (cityName)
            {
                case "Bansko":
                case "Borovets":
                    switch (packetType)
                    {
                        case "noEquipment":
                            pricePerNight = 80.00;

                            if (discountVip == "yes")
                            {
                                pricePerNight -= pricePerNight * 0.05;
                            }

                            break;

                        case "withEquipment":
                            pricePerNight = 100.00;

                            if (discountVip == "yes")
                            {
                                pricePerNight -= pricePerNight * 0.10;
                            }

                            break;

                        default:
                            Console.WriteLine("Invalid input!");
                            break;

                    }
                    break;

                case "Varna":
                case "Burgas":
                    switch (packetType)
                    {
                        case "noBreakfast":
                            pricePerNight = 100.00;

                            if (discountVip == "yes")
                            {
                                pricePerNight -= pricePerNight * 0.07;
                            }

                            break;

                        case "withBreakfast":
                            pricePerNight = 130.00;

                            if (discountVip == "yes")
                            {
                                pricePerNight -= pricePerNight * 0.12;
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid input!");
                            break;

                    }
                    break;

                default:
                    Console.WriteLine("Invalid input!");
                    break;

            }

            double totalPrice = pricePerNight * holidayDaysCount;

            if (totalPrice != 0)
            {
                Console.WriteLine($"The price is {totalPrice:f2}lv! Have a nice time!");
            }
           
        }
    }
}
