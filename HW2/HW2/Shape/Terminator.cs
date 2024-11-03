using System;

namespace HW2
{
    // Different shapes that inherit from the Shape class
    public class Terminator : Shape
    {
        // Constructor
        public Terminator(string shapeName, int X, int y, int width, int height) : base(
            shapeName, X, y, width, height)
        { }

        // Draw method
        public override void Draw(Igraphic graphic)
        {
            graphic.DrawArc(X, Y, H, H, 90, 180);
            graphic.DrawArc(X + W, Y, H, H, 270, 180);
            graphic.DrawLine(X + H / 2, Y, X + W + H / 2, Y);
            graphic.DrawLine(X + H / 2, Y + H, X + W + H / 2, Y + H);
            Console.WriteLine($"Drawing Terminator shape: {ShapeName} at ({X}, {Y}) with width {W} and height {H}");
        }
    }
}