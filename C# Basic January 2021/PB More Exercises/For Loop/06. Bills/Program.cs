using System;

namespace _06.Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());            

            const decimal waterBill = 20.00m;
            const decimal internetBill = 15.00m;
            decimal otherBill = 0.00m;
            decimal othersAllMonths = 0.00m;
            decimal electricityAllMonths = 0.00m;

            for (int i = 0; i < months; i++)
            {
                decimal electricityBill = decimal.Parse(Console.ReadLine());
                electricityAllMonths += electricityBill;
                otherBill = (electricityBill + waterBill + internetBill) * 1.20m;
                othersAllMonths += otherBill;
            }

            decimal waterAllMonths = waterBill * months;
            decimal internetAllMonths = internetBill * months;
            decimal averageAllMonths = (waterAllMonths + internetAllMonths + electricityAllMonths + othersAllMonths) / months;

            Console.WriteLine($"Electricity: {electricityAllMonths:f2} lv");
            Console.WriteLine($"Water: {waterAllMonths:f2} lv");
            Console.WriteLine($"Internet: {internetAllMonths:f2} lv");
            Console.WriteLine($"Other: {othersAllMonths:f2} lv");
            Console.WriteLine($"Average: {averageAllMonths:f2} lv");
        }
    }
}
