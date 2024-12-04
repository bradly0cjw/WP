using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HW2
{
    // Different shapes that inherit from the Shape class
    public class Terminator : Shape
    {
        // Constructor
        public Terminator(string shapeName, string text, int id, int x, int y, int width, int height, int biasX = 0, int biasY = 0) : base(shapeName, text, id, x, y,
            width, height, biasX, biasY)
        { }

        // Draw method
        public override void Draw(IGraphic graphic)
        {
            if (H != 0 || W != 0)
            {
                graphic.DrawArc(X, Y, H, H, 90, 180);
                graphic.DrawArc(X + W - H, Y, H, H, 270, 180);
                graphic.DrawLine(X + H / 2, Y, X + W - (H / 2), Y);
                graphic.DrawLine(X + H / 2, Y + H, X + W - (H / 2), Y + H);
                graphic.DrawString(Text, X + (W / 2) + BiasX, Y + (H / 2) + BiasY);
            }
        }

        public override bool IsClickInShape(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(X, Y, H, H, 90, 180);
            path.AddLine(X + H / 2, Y, X + W - (H / 2), Y);
            path.AddArc(X + W - H, Y, H, H, 270, 180);
            path.AddLine(X + H / 2, Y + H, X + W - (H / 2), Y + H);
            path.CloseFigure();
            return path.IsVisible(new Point(x, y));
        }

        public override bool IsClickOnText(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new Rectangle(X + (W / 2) + 30 + BiasX, Y + (H / 2) + BiasY, 5, 5));
            return path.IsVisible(new Point(x, y));
        }
    }
}