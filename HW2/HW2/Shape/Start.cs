using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace HW2
{
    // Different shapes that inherit from the Shape class
    public class Start : Shape
    {
        // Constructor
        public Start(string shapeName, string text, int id, int x, int y, int width, int height, int biasX = 0, int biasY = 0) : base(shapeName, text, id, x, y,
            width, height, biasX, biasY)
        { }

        // Draw method
        public override void Draw(IGraphic graphic)
        {
            //Console.WriteLine($"Drawing Start shape: {ShapeName} at ({X}, {Y}) with width {W} and height {H}");
            graphic.DrawEllipse(X, Y, W, H);
            graphic.DrawString(Text, X + (W / 2) + BiasX, Y + (H / 2) + BiasY);
        }

        public override bool IsClickInShape(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(X, Y, W, H);
            return path.IsVisible(new Point(x, y));
        }
        public override bool IsClickOnText(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new Rectangle(X + (W / 2) + 30 + BiasX, Y + (H / 2) + BiasY, 5, 5));
            return path.IsVisible(new Point(x, y));
        }

        public override void DrawConnectionPoint(IGraphic graphic)
        {
            graphic.DrawDot((X + W) / 2, Y, 10, 10);
            graphic.DrawDot(X, (Y + H) / 2, 10, 10);
            graphic.DrawDot((X + W) / 2, (Y + H), 10, 10);
            graphic.DrawDot((X + W), (Y + H) / 2, 10, 10);
        }
    }
}