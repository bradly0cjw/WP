using System;

namespace HW2
{
    // Different shapes that inherit from the Shape class
    public class Start : Shape
    {
        // Constructor
        public Start(string shapeName, int x, int y, int width, int height) : base(shapeName, x, y, width, height)
        {
        }

        // Draw method
        public override void Draw()
        {
            Console.WriteLine($"Drawing Start shape: {ShapeName} at ({X}, {Y}) with width {Width} and height {Height}");
        }
    }
}