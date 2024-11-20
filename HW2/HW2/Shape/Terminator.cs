using System;
using System.Drawing.Drawing2D;

namespace HW2
{
    // Different shapes that inherit from the Shape class
    public class Terminator : Shape
    {
        // Constructor
        public Terminator(string shapeName, string text, int id, int X, int y, int width, int height) : base(
            shapeName, text, id, X, y, width, height)
        {
        }

        // Draw method
        public override void Draw(IGraphic graphic)
        {
            if (H != 0 || W != 0)
            {
                graphic.DrawArc(X, Y, W, W, 90, 180);
                graphic.DrawArc(X + H - W, Y, W, W, 270, 180);
                graphic.DrawLine(X + W / 2, Y, X + H - (W / 2), Y);
                graphic.DrawLine(X + W / 2, Y + W, X + H - (W / 2), Y + W);
                Console.WriteLine($"Drawing Terminator shape: {ShapeName} at ({X}, {Y}) with width {W} and height {H}");
                graphic.DrawString(Text, X + (W / 2), Y + (H / 2));
            }

        }

        public override bool IsClickInShape(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(X, Y, W, W, 90, 180);
            path.AddLine(X + W / 2, Y, X + H + (W / 2), Y);
            path.AddArc(X + W, Y, W, W, 270, 180);
            path.AddLine(X + W / 2, Y + W, X + H - (W / 2), Y + W);
            path.CloseFigure();
            return path.IsVisible(new System.Drawing.Point((int)x, (int)y));
        }
    }
}