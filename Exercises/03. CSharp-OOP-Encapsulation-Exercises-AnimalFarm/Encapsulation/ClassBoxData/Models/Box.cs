namespace P01.ClassBoxData.Models
{
    using P01.ClassBoxData.Exceptions;
    using System;

    public class Box
    {
        private double length;

        private double width;

        private double height;

        public Box(double length,double width, double height)
        {
            this.Length = length;

            this.Width = width;

            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.LenghtZeroOrNegativeException);
                }

                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.WidthZeroOrNegativeException);
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeightZeroOrNegativeException);
                }

                this.height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            return 2 * (this.length * this.width) + CalculateLateralSurfaceArea();
        }

        public double CalculateLateralSurfaceArea()
        {
            return 2 * (this.length * this.height + this.width * this.height);
        }

        public double CalculateVolume()
        {
            return this.length * this.width * this.height;
        }
    }
}
