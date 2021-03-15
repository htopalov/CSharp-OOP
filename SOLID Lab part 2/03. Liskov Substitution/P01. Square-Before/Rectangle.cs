using System;
using System.Collections.Generic;
using System.Text;

namespace P01._Square_Before
{
    public class Rectangle : Shape
    {
        public override double Area => this.Width * this.Height;

        public double Width { get; set; }

        public double Height { get; set; }
    }
}
