using System;


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
            //Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            //Pen pen = new Pen(Color.Black, 2);
            //g.DrawEllipse(pen, x, y, w, h);
            Console.WriteLine($"Drawing Start shape: {ShapeName} at ({X}, {Y}) with width {W} and height {H}");
            graphic.DrawEllipse(X, Y, H, W);
            graphic.DrawString(Text, X + (W / 2), Y + (H / 2));
        }
    }
}