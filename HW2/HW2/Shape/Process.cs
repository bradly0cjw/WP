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
    public class Process : Shape
    {
        // Constructor
        public Process(string shapeName, string text, int id, int x, int y, int width, int height) : base(
            shapeName, text, id, x, y, width, height)
        {
        }

        // Draw method
        public override void Draw(IGraphic graphic)
        {
            graphic.DrawRectangle(X, Y, W, H);
            graphic.DrawString(Text, X + (W / 2), Y + (H / 2));
        }

        public override bool IsClickInShape(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new Rectangle(X, Y, W, H));

            return path.IsVisible(new Point(x, y));
        }

    }
}