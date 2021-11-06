using System;

namespace _02.MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int first = 1; first <= 10; first++)
            {
                for (int second = 1; second <= 10 ; second++)
                {
                    int result = first * second;
                    Console.WriteLine($"{first} * {second} = {result}");
                }
            }
        }
    }
}
