﻿using System;

namespace _02._TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double area = (a * h) / 2;
            Console.WriteLine($"{area:f2}");
        }
    }
}
