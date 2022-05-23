using System;

namespace _04.CinemaVoucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int vaucherValue = int.Parse(Console.ReadLine());

            int purchasePrice = 0;
            int ticketsBoughtCount = 0;
            int otherStaffsBoughtCount = 0;

            string input = Console.ReadLine(); 

            while (input != "End")
            {
                if (input.Length > 8)
                {
                    purchasePrice = input[0] + input[1];
                    if (purchasePrice <= vaucherValue)
                    {
                        vaucherValue -= purchasePrice;
                        ticketsBoughtCount++;
                    }
                    else
                    {
                        break;
                    }
                                  
                }
                else if (input.Length <= 8)
                {
                    purchasePrice = input[0];
                    if (purchasePrice <= vaucherValue)
                    {
                        vaucherValue -= purchasePrice;
                        otherStaffsBoughtCount++;
                    }
                    else
                    {
                        break;
                    }                    
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{ticketsBoughtCount}");
            Console.WriteLine($"{otherStaffsBoughtCount}");
        }
    }
}
