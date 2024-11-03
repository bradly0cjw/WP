using System;
using System.Drawing;

namespace HW2
{
    // Shape class to store the properties of a shape
    public class Shape
    {
        Igraphic _graphic;
        public string ShapeName { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        // Constructor
        public Shape(string shapeName, int x, int y, int width, int height)
        {
            ShapeName = shapeName;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        // Virtual method
        public virtual void Draw(int x, int y, int width, int height)
        {
            Console.WriteLine($"Drawing {ShapeName} at ({X}, {Y}) with width {Width} and height {Height}");
        }
    }
}