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
        private Igraphic _graphic;
        // Constructor
        public Decision(string shapeName, int x, int y, int width, int height, Igraphic graphic) : base(shapeName, x, y,
            width, height)
        {
            _graphic = graphic;
            Draw(x, y, width, height);
        }

        // Draw method
        public override void Draw(int x, int y, int w, int h)
        {
            Point[] points = new Point[4];
            points[0] = new Point((int)x, (int)(y + h / 2));
            points[1] = new Point((int)(x + w / 2), (int)y);
            points[2] = new Point((int)(x + w), (int)(y + h / 2));
            points[3] = new Point((int)(x + w / 2), (int)(y + h));
            _graphic.DrawPolygon(points);
            Console.WriteLine($"Drawing Decision shape: {ShapeName} at ({X}, {Y}) with width {Width} and height {Height}");
        }
    }
}
