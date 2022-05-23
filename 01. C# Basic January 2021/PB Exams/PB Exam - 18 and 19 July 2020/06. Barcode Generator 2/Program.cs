using System;

namespace _06.BarcodeGenerator2
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int barcode = start; barcode <= end; barcode++)
            {
                if (barcode % 2 == 0)
                {
                    continue;
                }
                
                string currentBarcode = barcode.ToString();
                int countOdd = 0;

                for (int index = 0; index < currentBarcode.Length; index++)
                {
                    int digit = int.Parse(currentBarcode[index].ToString());

                    if (digit % 2 != 0)
                    {
                        countOdd++;
                    }

                }

                if (countOdd == 4)
                {
                    Console.Write($"{currentBarcode} ");
                }

            }

        }
    }
}
