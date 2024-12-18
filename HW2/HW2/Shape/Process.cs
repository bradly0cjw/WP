using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    // Different shapes that inherit from the Shape class
    public class Process : Shape
    {
        private const int Radius = 10;
        // Constructor
        public Process(string shapeName, string text, int id, int x, int y, int width, int height, int biasX = 0, int biasY = 0) : base(shapeName, text, id, x, y,
            width, height, biasX, biasY)
        { }

        // Draw method
        public override void Draw(IGraphic graphic)
        {
            graphic.DrawRectangle(X, Y, W, H);
            graphic.DrawString(Text, X + (W / 2) + BiasX, Y + (H / 2) + BiasY);
        }

        public override bool IsClickInShape(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new Rectangle(X, Y, W, H));

            return path.IsVisible(new Point(x, y));
        }
        public override bool IsClickOnText(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            //Console.WriteLine(x+","+y);
            path.AddRectangle(new Rectangle(X + (W / 2) + 30 + BiasX, Y + (H / 2) + BiasY, 5, 5));
            //Console.WriteLine("Path "+(X + (W / 2)+30 + BiasX)+" " +(Y + (H / 2) + BiasY));
            return path.IsVisible(new Point(x, y));
        }

        public override void DrawConnectionPoint(IGraphic graphic)
        {
            //graphic.DrawDot(X,Y,Radius,Radius);
            graphic.DrawDot(X + (W / 2), Y, Radius, Radius);
            graphic.DrawDot(X + (W / 2), (Y + H), Radius, Radius);
            graphic.DrawDot((X + W), Y + (H / 2), Radius, Radius);
            graphic.DrawDot(X, Y + (H / 2), Radius, Radius);
        }

        public override int IsClickConnectionPoint(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new Rectangle(X + (W / 2), Y, Radius, Radius));
            if (path.IsVisible(x, y))
            {
                return 1;
            }
            path.AddRectangle(new Rectangle(X + (W / 2), (Y + H), Radius, Radius));
            if (path.IsVisible(x, y))
            {
                return 2;
            }
            path.AddRectangle(new Rectangle((X + W), Y + (H / 2), Radius, Radius));
            if (path.IsVisible(x, y))
            {
                return 3;
            }
            path.AddRectangle(new Rectangle(X, Y + (H / 2), Radius, Radius));
            if (path.IsVisible(x, y))
            {
                return 4;
            }
            return -1;

        }

        public override (int, int) GetConnectionPoint(int index)
        {
            switch (index)
            {
                case 1:
                    return (X + (W / 2), Y);
                case 2:
                    return (X + (W / 2), (Y + H));
                case 3:
                    return ((X + W), Y + (H / 2));
                case 4:
                    return (X, Y + (H / 2));
                default:
                    return (-1, -1);
            }
        }
    }
}