namespace Shapes
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(2,3);

            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());

            Shape circle = new Circle(5);

            Console.WriteLine(circle.Draw());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
        }
    }
}
