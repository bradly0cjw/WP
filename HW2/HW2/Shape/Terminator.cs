using System;

namespace HW2
{
    // Different shapes that inherit from the Shape class
    public class Terminator : Shape
    {
        private Igraphic _graphic;
        // Constructor
        public Terminator(string shapeName, int x, int y, int width, int height, Igraphic graphic) : base(
            shapeName, x, y, width, height)
        {
            _graphic = graphic;
            Draw(x, y, width, height);
        }

        // Draw method
        public override void Draw(int x, int y, int w, int h)
        {
            _graphic.DrawArc(x,y,h,h,90,180);
            _graphic.DrawArc(x+w,y,h,h,270,180);
            _graphic.DrawLine(x+h/2,y,x+w+h/2,y);
            _graphic.DrawLine(x + h / 2, y + h, x + w + h / 2, y + h);
            Console.WriteLine($"Drawing Terminator shape: {ShapeName} at ({X}, {Y}) with width {Width} and height {Height}");
        }
    }
}