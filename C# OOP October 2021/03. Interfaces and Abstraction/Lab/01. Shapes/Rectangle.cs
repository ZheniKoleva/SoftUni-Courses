using System;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private readonly int width;

        private readonly int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            Console.WriteLine(new string('*', this.width));

            for (int i = 1; i < this.height - 1; i++)
            {
                Console.WriteLine($"*{new string(' ', this.width - 2)}*");                
            }

            Console.WriteLine(new string('*', this.width));
        }
    }
}
