using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace HW2
{
    // Different shapes that inherit from the Shape class
    public class Start : Shape
    {
        // Constructor
        public Start(string shapeName, string text, int id, int x, int y, int width, int height) : base(shapeName, text, id, x, y, width, height)
        {
        }

        // Draw method
        public override void Draw(IGraphic graphic)
        {
            //Console.WriteLine($"Drawing Start shape: {ShapeName} at ({X}, {Y}) with width {W} and height {H}");
            graphic.DrawEllipse(X, Y, W, H);
            graphic.DrawString(Text, X + (W / 2), Y + (H / 2));
        }

        public override bool IsClickInShape(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(X, Y, W, H);
            return path.IsVisible(new Point(x, y));
        }

    }
}