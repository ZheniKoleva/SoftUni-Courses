using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private readonly double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
            => Math.PI * Math.Pow(this.radius, 2);

        public override double CalculatePerimeter()
            => Math.PI * this.radius * 2;

        public override string Draw()
            => base.Draw() + this.GetType().Name;
    }
}
