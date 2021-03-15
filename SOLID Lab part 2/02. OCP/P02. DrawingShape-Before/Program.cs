using P02._DrawingShape_Before.Contracts;
using System;

namespace P02._DrawingShape_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawingManager manager = new DrawingManager();
            Circle circle = new Circle();
            Rectangle rectangle = new Rectangle();
            manager.Draw(circle);
            manager.Draw(rectangle);
        }
    }
}
