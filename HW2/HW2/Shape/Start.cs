using System;
using System.Drawing;

namespace HW2
{
    // Different shapes that inherit from the Shape class
    public class Start : Shape
    {
        private Igraphic _graphic;

        // Constructor
        public Start(string shapeName, int x, int y, int width, int height, Igraphic graphic) : base(shapeName, x, y, width, height)
        {
            _graphic = graphic;
            Draw(x, y, width, height);
        }

        // Draw method
        public override void Draw(int x, int y, int w, int h)
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            Pen pen = new Pen(Color.Black, 2);
            g.DrawEllipse(pen, x, y, w, h);
            Console.WriteLine($"Drawing Start shape: {ShapeName} at ({X}, {Y}) with width {Width} and height {Height}");
            _graphic.DrawEllipse(x, y, w, h);
        }
    }
}