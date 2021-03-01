using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return this.length; }
            private set
            {
                if (value > 0)
                {
                    this.length = value;
                }
                else
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
            }
        }

        public double Width 
        { 
            get { return this.width; }
           private set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
            }
        }

        public double Height 
        {
            get { return this.height; }
            private set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
            }
        }

        public string SurfaceArea()
        {
            double surfaceArea = (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
            return $"Surface Area - {surfaceArea:f2}";
        }
        public string LateralSurfaceArea()
        {
            double lateralSurfaceArea = (2 * Length * Height) + (2 * Width * Height);
            return $"Lateral Surface Area - {lateralSurfaceArea:f2}";
        }
        public string Volume()
        {
            double volume = Length * Width * Height;
            return $"Volume - {volume:f2}";
        }

    }
}
