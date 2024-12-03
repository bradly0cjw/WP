using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    // Different shapes that inherit from the Shape class
    public class Decision : Shape
    {
        // Constructor
        public Decision(string shapeName, string text, int id, int x, int y, int width, int height) : base(shapeName, text, id, x, y,
            width, height)
        { }

        // Draw method
        public override void Draw(IGraphic graphic)
        {
            graphic.DrawPolygon(X,Y,W,H);
            graphic.DrawString(Text, X + (W / 2), Y + (H / 2));
            //Console.WriteLine($"Drawing Decision shape: {ShapeName} at ({X}, {Y}) with width {W} and height {H}");
        }

        public override bool IsClickInShape(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            Point[] points = new Point[4];

            points[0] = new Point(X + W / 2, Y);
            points[1] = new Point(X + W, Y + H / 2);
            points[2] = new Point(X + W / 2, Y + H);
            points[3] = new Point(X, Y + H / 2);

            path.AddPolygon(points);

            return path.IsVisible(new Point(x, y));
        }

    }
}
