using System;

namespace _06._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine().ToLower();

            double area = 0.00;

            if (figureType == "square")
            {
                double side = double.Parse(Console.ReadLine());
                area = side * side;
            }
            else if (figureType == "rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                area = sideA * sideB;
            }
            else if (figureType == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                area = Math.PI * radius * radius;
            }
            else if (figureType == "triangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                area = (sideA * h) / 2;
            }
            Console.WriteLine($"{area:f3}");
        }
    }
}
