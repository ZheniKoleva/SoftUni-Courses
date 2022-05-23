using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double pricePerPerson = 0.0;

            switch (groupType)
            {
                case "Students":
                    if (dayOfWeek == "Friday")
                    {
                        pricePerPerson = 8.45;
                    }
                    else if (dayOfWeek == "Saturday")
                    {
                        pricePerPerson = 9.80;
                    }
                    else if (dayOfWeek == "Sunday")
                    {
                        pricePerPerson = 10.46;
                    }

                    break;

                case "Business":
                    if (dayOfWeek == "Friday")
                    {
                        pricePerPerson = 10.90;
                    }
                    else if (dayOfWeek == "Saturday")
                    {
                        pricePerPerson = 15.60;
                    }
                    else if (dayOfWeek == "Sunday")
                    {
                        pricePerPerson = 16.00;
                    }

                    break;

                case "Regular":
                    if (dayOfWeek == "Friday")
                    {
                        pricePerPerson = 15.00;
                    }
                    else if (dayOfWeek == "Saturday")
                    {
                        pricePerPerson = 20.00;
                    }
                    else if (dayOfWeek == "Sunday")
                    {
                        pricePerPerson = 22.50;
                    }

                    break; 
                   
            }

            double totalPrice = pricePerPerson * groupCount;

            if (groupType == "Students" && groupCount >= 30)
            {
                totalPrice *= 0.85;
            }
            else if (groupType == "Regular" 
                && (groupCount >= 10 && groupCount <= 20))
            {
                totalPrice *= 0.95;
            }
            else if (groupType == "Business" && groupCount >= 100)
            {
                groupCount -= 10;
                totalPrice = groupCount * pricePerPerson;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
