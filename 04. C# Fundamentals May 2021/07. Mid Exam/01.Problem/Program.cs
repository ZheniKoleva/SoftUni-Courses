using System;

namespace _01.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int ordersCount = int.Parse(Console.ReadLine());

            double totalPrice = 0;

            for (int i = 0; i < ordersCount; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                //int days = int.Parse(Console.ReadLine());
                //int capsulesCount = int.Parse(Console.ReadLine());

                //double pricePerOrder = ((days * capsulesCount) * pricePerCapsule);

                byte days = byte.Parse(Console.ReadLine());
                short capsulesCount = short.Parse(Console.ReadLine());

                double pricePerOrder = ((int)(days * capsulesCount) * pricePerCapsule);

                Console.WriteLine($"The price for the coffee is: ${pricePerOrder:f2}");

                totalPrice += pricePerOrder;
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");

        }
    }
}
