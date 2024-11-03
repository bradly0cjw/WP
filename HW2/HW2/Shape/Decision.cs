using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    // Different shapes that inherit from the Shape class
    public class Decision : Shape
    {
        // Constructor
        public Decision(string shapeName, int x, int y, int width, int height) : base(shapeName, x, y,
            width, height) { }

        // Draw method
        public override void Draw(Igraphic graphic)
        {
            Point[] points = new Point[4];
            points[0] = new Point(X, Y+H / 2);
            points[1] = new Point(X+W/2, Y);
            points[2] = new Point(X, Y + H / 2);
            points[3] = new Point(X + W / 2, Y);
            graphic.DrawPolygon(points);
            Console.WriteLine($"Drawing Decision shape: {ShapeName} at ({X}, {Y}) with width {W} and height {H}");
        }
    }
}
