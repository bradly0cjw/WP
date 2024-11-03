using System;

namespace HW2
{
    // Different shapes that inherit from the Shape class
    public class Terminator : Shape
    {
        // Constructor
        public Terminator(string shapeName, int x, int y, int width, int height) : base(shapeName, x, y, width, height) { }

        // Draw method
        public override void Draw(int x, int y, int w, int h)
        {
            Console.WriteLine($"Drawing Terminator shape: {ShapeName} at ({X}, {Y}) with width {Width} and height {Height}");
        }
    }
}