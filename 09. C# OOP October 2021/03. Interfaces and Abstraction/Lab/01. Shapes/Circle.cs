using System;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private readonly int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }       

        public void Draw()
        {           
            double pointIn = this.radius - 0.4;
            double pointOut = this.radius + 0.4;

            for (double i = -this.radius; i <= this.radius; i++)
            {
                for (double j = -this.radius; j < pointOut; j += 0.5)
                {
                    double x = Math.Pow(i, 2);
                    double y = Math.Pow(j, 2);
                    double distance = Math.Sqrt(x + y);

                    if (distance >= pointIn && distance <= pointOut)
                    {
                        Console.Write('*');
                        continue;
                    }

                    Console.Write(' ');
                }

                Console.WriteLine();
            }
        }
    }
}
