namespace Shapes
{
    public class Rectangle : Shape
    {
        private readonly double height;

        private readonly double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
            => this.height * this.width;

        public override double CalculatePerimeter()
            => (this.height + this.width) * 2;

        public override string Draw()
            => base.Draw() + this.GetType().Name;       
    }
}
