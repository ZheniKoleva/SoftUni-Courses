using System;

namespace _04.CarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int first = start; first <= end; first++)
            {
                for (int second = start; second <= end; second++)
                {
                    for (int third = start; third <= end; third++)
                    {
                        for (int fourth = start; fourth <= end; fourth++)
                        {
                            bool isEvenAndOdd = (first % 2 == 0 && fourth % 2 != 0) || (first % 2 != 0 && fourth % 2 == 0);
                            bool isLarger = first > fourth;
                            bool sumIsEven = (second + third) % 2 == 0;

                            if (isEvenAndOdd && isLarger && sumIsEven)
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
