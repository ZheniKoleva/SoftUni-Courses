﻿using System;

namespace _03.ExactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCount = int.Parse(Console.ReadLine());

            decimal sum = 0;            

            for (int i = 0; i < numberCount; i++)
            {
                sum += decimal.Parse(Console.ReadLine());
            }           

            Console.WriteLine(sum);
        }
    }
}
