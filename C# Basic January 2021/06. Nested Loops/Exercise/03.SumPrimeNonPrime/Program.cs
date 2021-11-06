using System;

namespace _03.SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            int sumPrime = 0;
            int sumNonPrime = 0;
            bool isPrime = true;
            
            while (number != "stop")
            {
                int currentNum = int.Parse(number);

                if (currentNum < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else if (currentNum == 2)
                {
                    sumPrime += currentNum;                    
                }
                else if (currentNum == 1 || currentNum % 2 == 0)
                {
                    sumNonPrime += currentNum;
                }
                else
                {
                    for (int i = 3; i <= Math.Floor(Math.Sqrt(currentNum)); i += 2)
                    {
                        if (currentNum % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime)
                    {
                        sumPrime += currentNum;
                    }
                    else
                    {
                        sumNonPrime += currentNum;
                        isPrime = true;
                    }
                    
                }

                number = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
        }
    }
}
