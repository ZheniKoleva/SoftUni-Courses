using System;

namespace _13.PrimePairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int startPair1 = int.Parse(Console.ReadLine());
            int startPair2 = int.Parse(Console.ReadLine());
            int stepToEnd1 = int.Parse(Console.ReadLine());
            int stepToEnd2 = int.Parse(Console.ReadLine());

            int endPair1 = startPair1 + stepToEnd1;
            int endPair2 = startPair2 + stepToEnd2;


            for (int pair1 = startPair1; pair1 <= endPair1; pair1++)
            {
                for (int pair2 = startPair2; pair2 <= endPair2; pair2++)
                {
                    if (pair1 % 2 == 0 || pair2 % 2 == 0)
                    {
                        continue;
                    }

                    bool isPrimePair1 = true;

                    var boundaryPair1 = (int)Math.Floor(Math.Sqrt(pair1));
                    for (int i = 3; i <= boundaryPair1; i += 2)
                    {
                        if (pair1 % i == 0)
                        {
                            isPrimePair1 = false;
                        }                        
                    }

                    bool isPrimePair2 = true;

                    var boundaryPair2 = (int)Math.Floor(Math.Sqrt(pair2));
                    for (int i = 3; i <= boundaryPair2; i += 2)
                    {
                        if (pair2 % i == 0)
                        {
                            isPrimePair2 = false;
                        }                        
                    }

                    if (isPrimePair1 && isPrimePair2)
                    {
                        Console.WriteLine($"{pair1}{pair2}");                       
                    }
                }
            }
        }
    }
}
