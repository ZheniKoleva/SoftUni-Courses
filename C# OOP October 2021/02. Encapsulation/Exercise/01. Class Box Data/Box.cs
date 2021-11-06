namespace _01.ClassBoxData
{
    using System;

    public class Box
    {
        private double length;

        private double width;

        private double height;

        public Box(double length, double width, double heght)
        {
            this.Length = length;
            this.Width = width;
            this.Height = heght;
        }

        public double Length 
        { 
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;                
            } 
        }
        
        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public string CalculateSurfaceArea()   //2lw + 2lh + 2wh
        {
            double area = ((this.length * this.width)
                          + (this.length * this.height)
                          + (this.width * this.height)) * 2;

            return $"Surface Area - {area:f2}";
        }


        public string CalculateLateralSurfaceArea() //2lh + 2wh
        { 
            double area =  ((this.length * this.height) 
                           + (this.height * this.width)) * 2;

            return $"Lateral Surface Area - {area:f2}";
        }


        public string CalculateVolume() // lhw
        { 
            double volume = this.length * this.height * this.width;

            return $"Volume - {volume:f2}";
        }        
    }
}
