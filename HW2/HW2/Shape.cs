using System;

namespace HW2
{
    // Shape class to store the properties of a shape
    public class Shape
    {
        public string ShapeName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

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
        public virtual void Draw(int x, int y, int w, int h)
        {
            Console.WriteLine($"Drawing {ShapeName} at ({X}, {Y}) with width {Width} and height {Height}");
        }
    }
}