using System;
using System.Collections.Generic;
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
            width, height) { }

        // Draw method
        public override void Draw(IGraphic graphic)
        {
            Point[] points = new Point[4];
            points[0] = new Point((int)(X + H / 2), (int)Y);
            points[1] = new Point((int)(X + H), (int)(Y + W / 2));
            points[2] = new Point((int)(X + H / 2), (int)(Y + W));
            points[3] = new Point((int)X, (int)(Y + W / 2));
            graphic.DrawPolygon(points);
            graphic.DrawString(Text, X + (W / 2), Y + (H / 2));
            Console.WriteLine($"Drawing Decision shape: {ShapeName} at ({X}, {Y}) with width {W} and height {H}");
        }
    }
}
