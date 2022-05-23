using System;

namespace _03.MobileOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            string contractDuration = Console.ReadLine().ToLower();
            string contractType = Console.ReadLine().ToLower();
            string mobileInternet = Console.ReadLine().ToLower();
            int monthsToPay = int.Parse(Console.ReadLine());

            const double discountFor2YearsContract = 0.0375;
            double tax = 0.00;

            switch (contractType)
            {
                case "small":
                    switch (contractDuration)
                    {
                        case "one":
                            tax = 9.98;
                            break;
                        case "two":
                            tax = 8.58;
                            break;
                    }
                    break;

                case "middle":
                    switch (contractDuration)
                    {
                        case "one":
                            tax = 18.99;
                            break;
                        case "two":
                            tax = 17.09;
                            break;
                    }
                    break;

                case "large":
                    switch (contractDuration)
                    {
                        case "one":
                            tax = 25.98;
                            break;
                        case "two":
                            tax = 23.59;
                            break;
                    }
                    break;

                case "extralarge":
                    switch (contractDuration)
                    {
                        case "one":
                            tax = 35.99;
                            break;
                        case "two":
                            tax = 31.79;
                            break;
                    }
                    break;

            }

            switch (mobileInternet)
            {
                case "yes":
                    if (tax <= 10.00)
                    {
                        tax += 5.50;
                    }
                    else if (tax <= 30.00)
                    {
                        tax += 4.35;
                    }
                    else if (tax > 30.00)
                    {
                        tax += 3.85;
                    }
                    break;
            }

            if (contractDuration == "two")
            {
                tax -= tax * discountFor2YearsContract;
            }

            double totalPrice = tax * monthsToPay;

            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
