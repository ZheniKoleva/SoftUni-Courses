using System;

namespace _06.BarcodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
                        

            int last1 = start % 10;
            int third1 = (start / 10) % 10;
            int second1 = (start / 100) % 10;
            int first1 = start / 1000;

            int last2 = end % 10;
            int third2 = (end / 10) % 10;
            int second2 = (end / 100) % 10;
            int first2 = end / 1000;

            for (int first = first1; first <= first2; first++)
            {
                for (int second = second1; second <= second2; second++)
                {
                    for (int third = third1; third <= third2; third++)
                    {
                        for (int fourth = last1; fourth <= last2; fourth++)
                        {
                            bool isOdd = first % 2 != 0 && second % 2 != 0 && third % 2 != 0 && fourth % 2 != 0;

                            if (isOdd)
                            {
                                Console.Write($"{first}{second}{third}{fourth} ");
                            }

                        }

                    }

                }

            }

        }
    }
}
